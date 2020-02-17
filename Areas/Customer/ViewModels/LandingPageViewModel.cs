using CruiseCMSDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseCMSDemo.Models.ViewModels
{
    public class LandingPageViewModel
    {
        public IEnumerable<Itinerary> Itinerary { get; set; }
        public IEnumerable<Admin> Admin { get; set; }

    }
}
