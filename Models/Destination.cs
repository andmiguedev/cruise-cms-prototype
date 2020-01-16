using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseCMSDemo.Models
{
    public class Destination
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Region { get; set; }
        public string Country { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public string Motto { get; set; }
        [Required]
        public string Address { get; set; }
        public string Population { get; set; }
        [Required]
        public byte[] Picture { get; set; }

    }
}
