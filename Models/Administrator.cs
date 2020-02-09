using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseCMSDemo.Models
{
    public class Administrator
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name of Employee")]
        public int PersonnelId { get; set; }
        
        [ForeignKey("PersonnelId")]
        public virtual Personnel Employee { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Display(Name = "Banner Image")]
        public string Background { get; set; }
        [Display(Name = "Banner Slogan")]
        public string Description { get; set; }
    }
}
