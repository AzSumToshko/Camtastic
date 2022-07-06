using Camtastic.Entity;
using System;
using System.Collections.Generic;
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
        public void addPhoto(Photo item)
        {
            context.Photos.Add(item);
            context.SaveChanges();
        }
    }
}
