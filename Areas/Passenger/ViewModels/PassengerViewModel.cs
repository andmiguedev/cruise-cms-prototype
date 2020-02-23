using CruiseCMSDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseCMSDemo.Models.ViewModels
{
    /**
     * Passenger information to be passed as objects
     * or IEnumerable lists to different page Views.
     * Some data types can be passed as TempData
     */
    public class PassengerViewModel
    {
        public IEnumerable<Itinerary> DestinationList { get; set; }
        
        public Profile Profile { get; set; }
        public IEnumerable<Profile> ProfileNames { get; set; }
        public Preference Preference { get; set; }
        public string ErrorMessage { get; set; }
    }
}