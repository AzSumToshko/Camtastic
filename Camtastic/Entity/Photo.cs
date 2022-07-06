using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camtastic.Entity
{
    [Table("Photos")]
    internal class Photo
    {
        [Key]
        public int ID { get; set; }
        public string URL { get; set; }
        public int rating { get; set; }


        public int? cameraID { get; set; }
        [ForeignKey("cameraID")]
        public virtual Camera camera { get; set; }
    }
}
