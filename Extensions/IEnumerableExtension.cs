using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseCMSDemo.Extensions
{
    public static class IEnumerableExtension
    {
        /**
         * Convert an Itinerary object into IEnumerable list
         * of Destinations using SelectListItem function
         */ 
        public static IEnumerable<SelectListItem> DropdownList<Itinerary>(
            this IEnumerable<Itinerary> items, int selectedValue)
        {
            return from item in items
                select new SelectListItem
                {
                    Text = item.GetPropertyValue("Destination"),
                    Value = item.GetPropertyValue("Id"),
                    Selected = item.GetPropertyValue("Id")
                        .Equals(selectedValue.ToString())
                };
        }

        public static IEnumerable<SelectListItem> DropdownName<profile>(
            this IEnumerable<profile> items, int selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("FirstName"),
                       Value = item.GetPropertyValue("Id"),
                       Selected = item.GetPropertyValue("Id")
                           .Equals(selectedValue.ToString())
                   };
        }
    }
}
