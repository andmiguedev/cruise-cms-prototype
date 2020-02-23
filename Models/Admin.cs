using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseCMSDemo.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Administrator Name")]
        [Required]
        public string FullName { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        public string EmailAddress { get; set; }
        
        [StringLength(15, MinimumLength = 7)]
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
   
        [Display(Name = "Banner Image")]
        public byte[] Image { get; set; }
        
        [Display(Name = "Banner Slogan")]
        public string Description { get; set; }
    }
}
