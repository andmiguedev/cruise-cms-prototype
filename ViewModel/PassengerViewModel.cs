using CruiseCMSDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseCMSDemo.ViewModel
{
    public class PassengerViewModel
    {
        public IEnumerable<Itinerary> SelectDestination { get; set; }
        public Profile Profile { get; set; }
        public string ErrorMessage { get; set; }
    }
}
