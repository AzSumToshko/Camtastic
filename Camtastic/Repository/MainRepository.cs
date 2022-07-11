using Camtastic.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camtastic.Repository
{
    internal class MainRepository
    {
        private readonly Context context;
        public MainRepository()
        {
            context = new Context();
        }
        
        public void addCamera(Camera item)
        {
            context.Cameras.Add(item);
            context.SaveChanges();
        }

        public Camera findCamera(string brand , string model)
        {
            foreach (Camera item in context.Cameras)
            {
                if (item.model.Equals(model) && item.brand.Equals(brand))
                {
                    return item;
                }
            }
            return null;
        }

        internal List<Camera> getAllCameras()
        {
            return context.Cameras.ToList();
        }

        public void addPhoto(Photo item)
        {
            context.Photos.Add(item);
            context.SaveChanges();
        }

        public bool photoIsExisting(Photo photo)
        {
            foreach(Photo item in context.Photos)
            {
                if (item.URL.Equals(photo.URL))
                {
                    return true;
                }
            }
            return false;
        }

        public bool cameraIsExisting(Camera camera)
        {
            foreach(Camera item in context.Cameras)
            {
                if (camera.model == item.model && camera.brand == item.brand)
                {
                    return true;
                }
            }
            return false;
        }

        internal void updatePhoto(Photo photo)
        {
            Photo updatePhoto = null;

            foreach(Photo item in context.Photos)
            {
                if (item.URL.Equals(photo.URL))
                {
                    updatePhoto = item;
                }
            }

            updatePhoto.rating = photo.rating;

            context.Entry(updatePhoto).State = EntityState.Modified;
            context.SaveChanges();
        }

        internal Photo bestPhoto()
        {
            Photo photo = context.Photos.Find(1);

            foreach(Photo item in context.Photos)
            {
                if (photo.rating < item.rating)
                {
                    photo = item;
                }
            }

            return photo;
        }

        internal List<Photo> getByCamera(int id)
        {
            List<Photo> list = new List<Photo>();

            foreach (var item in context.Photos)
            {
                if (item.cameraID == id)
                    list.Add(item);
            }

            return list;
        }
    }
}
