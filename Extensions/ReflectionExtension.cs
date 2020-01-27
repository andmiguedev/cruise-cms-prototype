using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseCMSDemo.Extensions
{
    public static class ReflectionExtension
    {
        /**
         * Access the property values from the Itinerary 
         * Model that are needed by the Extension method 
         */ 
        public static string GetPropertyValue<Itinerary>(
            this Itinerary item, string destination)
        {
            return item.GetType().GetProperty(destination)
                .GetValue(item, null).ToString();
        }
    }
}
