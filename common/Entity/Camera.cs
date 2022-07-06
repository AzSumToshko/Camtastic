using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common.Entity
{
    [Table("Cameras")]
    internal class Camera
    {
        [Key]
        public int ID { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
    }
}
