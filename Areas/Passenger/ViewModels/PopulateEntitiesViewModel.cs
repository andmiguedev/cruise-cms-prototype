using CruiseCMSDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseCMSDemo.Models.ViewModels
{
    /**
     * Approach to get a list of Profiles using 
     * the ProfileId as a foreign key in Itinerary 
     * table. Extension methods are used to fill
     * the select tag with recent Destinations.
     */
    public class PopulateEntitiesViewModel
    {
        public IEnumerable<Itinerary> Itinerary { get; set; }
        public IEnumerable<Profile> Profile { get; set; }
        public Preference Preference { get; set; }
    }
}
