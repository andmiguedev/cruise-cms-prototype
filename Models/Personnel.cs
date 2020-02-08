using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseCMSDemo.Models
{
    public class Personnel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Day of Birth")]
        [Required]
        public DateTime DOB { get; set; }

        public string Gender { get; set; }
        public enum Sex
        {
            Male = 1,
            Female = 2
        }

        [Display(Name = "Assigned Cruise")]
        public string Fleet { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Start Date")]
        [Required]
        public DateTime StartDate { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "End Date")]
        [Required]
        public DateTime EndDate { get; set; }
        
        public string Industry { get; set; }
        public enum JobType
        {
            Entertainment = 1,
            Accomodation = 2,
            Catering = 3,
            Service = 4
        }

        [Required]
        public string Duties { get; set; }

        [Display(Name = "Years of Experience")]
        [Required]
        public int Experience { get; set; }

        [Display(Name = "Annual Salary")]
        [Required]
        public double Salary { get; set; }
    }
}
