using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Windows.Forms;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Camtastic.Repository;
using Camtastic.Entity;

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
        }

        private void search_ClickEvent(object sender, EventArgs e)
        {
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

            //checks if the url we search have an existing picture
            try
            {
                driver.FindElement(By.XPath("//button[@id='exifInfoMobile']")).Click();
                //new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='exifInfoMobile']"))).Click();
            }
            catch (Exception ex)
            {
                exceptionsLabel.Text = "The image you search is not found or its deleted !!";
                return;
            }

            
            //extracting the brand and the model out of the html
            string brand = driver.FindElement(
                By.XPath("/html/body/div[4]/div[5]/div[1]/div[1]/div/div[2]/div/div[2]/div[1]/div[2]/span")
                ).Text;

            string model = driver.FindElement(
                By.XPath("/html/body/div[4]/div[5]/div[1]/div[1]/div/div[2]/div/div[2]/div[2]/div[2]/span")
                ).Text;

            //checks if theres info on the rows for brand and model
            if (brand.Equals("") && model.Equals(""))
            {
                exceptionsLabel.Text = "The photo you are searching doesnt have information about the camera !!";
                return;
            }
                

            //checking if we have extracted exactly the model and the brand else we return 
            DateTime date;
            if (DateTime.TryParse(brand, out date))
                return;

            //create and fill the camera and photo entity
            Camera camera = new Camera();
            camera.brand = brand;
            camera.model = model;

            //inserting the camera into the database
            repo.addCamera(camera);

            Photo photo = new Photo();
            photo.URL = url;
            photo.rating = int.Parse(
                driver.FindElement(
                    By.XPath("/html/body/div[4]/div[5]/div[2]/div/div/div[2]/div/ul[1]/li[1]/ul/li[1]/span[2]/span")
                    ).Text);
            photo.cameraID = repo.findCamera(brand, model).ID;
            photo.camera = repo.findCamera(brand, model);

            //inserting the photo into the database
            repo.addPhoto(photo);

            //creating and displaying the message to the textbox
            string message = $"Photo: \n" +
                                $"URL: {photo.URL}\n Rating: {photo.rating}\\n" +
                                $"Camera:\n" +
                                $"Brand: {brand}\n model: {camera.model}";
            displayBox.Text = message;
        }

        //checks the url wether its correct
        public bool urlIsAvailable(string url)
        {
            if (url.Contains("https://photo-forum.net/i/"))
                return true;

            return false;
        }
    }
}
