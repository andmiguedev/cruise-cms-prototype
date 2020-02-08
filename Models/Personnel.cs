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
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Day of Birth")]
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
        public DateTime StartDate { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        
        public string Industry { get; set; }
        public enum JobType
        {
            Entertainment = 1,
            Accomodation = 2,
            Catering = 3,
            Service = 4
        }

        public string Duties { get; set; }

        [Display(Name = "Years of Experience")]
        public int Experience { get; set; }

        [Display(Name = "Annual Salary")]
        public double Salary { get; set; }
    }
}
