using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Windows.Forms;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Camtastic.Repository;
using Camtastic.Entity;
using Microsoft.VisualBasic;

namespace Camtastic
{
    public partial class MainScreen : Form
    {
        //properties
        private static IWebDriver driver;
        private static MainRepository repo;

        //constructor
        public MainScreen()
        {
            InitializeComponent();
            repo = new MainRepository();

            cameraBox.DataSource = repo.getAllCameras();
            cameraBox.ValueMember = "ID";
            cameraBox.DisplayMember = "model";
        }

        private void search_ClickEvent(object sender, EventArgs e)
        {
            exceptionsLabel.Text = "";
            //extracting the url from the textbox
            string url = linkInput_textBox.Text;

            //Checks if the url covers the requirements
            if (!urlIsAvailable(url))
            {
                exceptionsLabel.Text = "Invalid URL !!";
                return;
            }
                

            //instancing the driver
            driver = new ChromeDriver(@"D:\chromedriver2\");

            //navigating to the site
            driver.Navigate().GoToUrl(url);


            //extracting the brand and the model out of the html and checks if the photo we search is found
            string brand = "";
            string model = "";
            try 
            { 
                brand = driver.FindElement(
                    By.XPath("/html/body/div[4]/div[5]/div[1]/div[1]/div/div[2]/div/div[2]/div[1]/div[2]/span")
                    ).GetAttribute("textContent");

                model = driver.FindElement(
                    By.XPath("/html/body/div[4]/div[5]/div[1]/div[1]/div/div[2]/div/div[2]/div[2]/div[2]/span")
                    ).GetAttribute("textContent");
            }
            catch (Exception ex)
            {
                exceptionsLabel.Text = "The photo you are searching is deleted or doesnt exist !!";
                return;
            }

            //checking if we have extracted exactly the model and the brand else we return 
            DateTime date;
            if (DateTime.TryParse(brand, out date))
            {
                exceptionsLabel.Text = "Theres no metadata for this photo !!";
                return;
            }


            //create and fill the camera and photo entity
            Camera camera = new Camera();
            camera.brand = brand;
            camera.model = model;

            //inserting the camera into the database
            if (!repo.cameraIsExisting(camera))
                repo.addCamera(camera);

            Photo photo = new Photo();
            photo.URL = url;
            photo.rating = int.Parse(
                driver.FindElement(
                    By.XPath("/html/body/div[4]/div[5]/div[2]/div/div/div[2]/div/ul[1]/li[1]/ul/li[1]/span[2]/span")
                    ).Text);
            photo.cameraID = repo.findCamera(brand, model).ID;
            photo.camera = repo.findCamera(brand, model);

            //inserting the photo into the database if absent and if its present updates the rating
            if (!repo.photoIsExisting(photo))
                repo.addPhoto(photo);
            else
                repo.updatePhoto(photo);

            //creating and displaying the message to the textbox

            displayBox.Text = "Photo:" + ControlChars.NewLine +
                                $"URL: {photo.URL} "+ ControlChars.NewLine + 
                                $"Rating: {photo.rating}" + ControlChars.NewLine + ControlChars.NewLine +
                                $"Camera:" + ControlChars.NewLine +
                                $"Brand: {brand} "+ ControlChars.NewLine + 
                                $"Model: {camera.model}";
            driver.Close();
        }

        //checks the url wether its correct
        public bool urlIsAvailable(string url)
        {
            if (url.Contains("https://photo-forum.net/i/"))
                return true;

            return false;
        }

        private void cameraBoc_ClickEvent(object sender, EventArgs e)
        {
            Camera camera = cameraBox.SelectedItem as Camera;

            displayBox.Text =   $"Camera:" + ControlChars.NewLine +
                                $"Brand: {camera.brand} " + ControlChars.NewLine +
                                $"Model: {camera.model}";

            var photoOfCamera = repo.getByCamera(camera.ID);

            displayBox.Text += "Photos of that camera" + ControlChars.NewLine;
            int counter = 1;
            foreach (var photo in photoOfCamera)
            {
                displayBox.Text += ControlChars.NewLine +
                                $"Photo {counter}" + ControlChars.NewLine + 
                                $"URL: {photo.URL} " + ControlChars.NewLine +
                                $"Rating: {photo.rating}";
                counter++;
            }
        }

        private void bestPhotoBtn_Click(object sender, EventArgs e)
        {
            Photo photo = repo.bestPhoto();

            displayBox.Text = "Photo:" + ControlChars.NewLine +
                                $"URL: {photo.URL} " + ControlChars.NewLine +
                                $"Rating: {photo.rating}" + ControlChars.NewLine + ControlChars.NewLine +
                                $"Camera:" + ControlChars.NewLine +
                                $"Brand: {photo.camera.brand} " + ControlChars.NewLine +
                                $"Model: {photo.camera.model}";
        }
    }
}
