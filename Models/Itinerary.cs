using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseCMSDemo.Models
{
    public class Itinerary
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Sail From")]
        [Required]
        public string Origin { get; set; }
        
        
        [Display(Name = "Sail To")]
        [Required]
        public string Destination { get; set; }

        [Display(Name = "Cruise starts")]
        [Required]
        public string StartTime { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date of Departure")]
        [Required]
        public DateTime DepartureDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date of Arrival")]
        [Required]
        public DateTime ArrivalDate { get; set; }
        
        [Display(Name = "Cruise returns")]
        [Required]
        public string ReturnTime { get; set; }

        [Display(Name = "Number of days")]
        [Required]
        public int NumberOfDays { get; set; }
       
    }
}
