using Camtastic.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camtastic.Repository
{
    internal class Context : DbContext
    {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Camera> Cameras { get; set; }

        public Context() : base("Server = localhost\\sqlexpress; Database=Camtastic;Trusted_Connection=True;")
        {
            Photos = this.Set<Photo>();
            Cameras = this.Set<Camera>();
        }
    }
}
