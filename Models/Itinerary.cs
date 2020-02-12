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
        [StringLength(50, MinimumLength = 5)]
        [Required]
        public string Origin { get; set; }
        
        
        [Display(Name = "Sail To")]
        [StringLength(50, MinimumLength = 5)]
        [Required]
        public string Destination { get; set; }

        [Display(Name = "Cruise starts")]
        [Required]
        public string StartTime { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date of Departure")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DepartureDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date of Arrival")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime ArrivalDate { get; set; }
        
        [Display(Name = "Cruise returns")]
        [Required]
        public string ReturnTime { get; set; }

        [Display(Name = "Number of days")]
        [Range(1, 30)]
        [Required]
        public int NumberOfDays { get; set; }
       
    }
}
