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
        public string Origin { get; set; }
        
        [Display(Name = "Sail To")]
        public string Destination { get; set; }

        [Display(Name = "Cruise starts")]
        public double StartTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date of Departure")]
        public DateTime DepartureDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date of Arrival")]
        public DateTime ArrivalDate { get; set; }
        
        [Display(Name = "Cruise returns")]
        public double ReturnTime { get; set; }

        [Display(Name = "Number of days")]
        public int NumberOfDays { get; set; }
       
    }
}
