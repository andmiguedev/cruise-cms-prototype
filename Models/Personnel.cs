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

        [Display(Name = "First Name")]
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "MI")]
        [StringLength(1)]
        public string MiddleInitials { get; set; }
        
        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 5)]
        [Required]
        public string LastName { get; set; }

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
        [StringLength(20)]
        public string Fleet { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
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
        [Range(1, 20)]
        public int Experience { get; set; }

        [Display(Name = "Annual Salary")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Required]
        public decimal Salary { get; set; }
    }
}
