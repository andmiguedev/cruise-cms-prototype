using CruiseCMSDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseCMSDemo.Models.ViewModels
{
    public class PassengerViewModel
    {
        public IEnumerable<Itinerary> DestinationList { get; set; }
        public Profile Profile { get; set; }
        public Preference Preference { get; set; }
        public string ErrorMessage { get; set; }
    }
}
