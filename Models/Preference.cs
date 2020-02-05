using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseCMSDemo.Models
{
    public class Preference
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Passenger Name")]
        public int ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }

        [Display(Name = "Trip Destination")]
        public int ItineraryId { get; set; }
        [ForeignKey("ItineraryId")]
        public virtual Itinerary Itinerary { get; set; }

        public string Cabin { get; set; }
        public string Events { get; set; }
        public string Tours { get; set; }
        public string Excursions { get; set; }
        public string Activities { get; set; }

        [Display(Name = "Visited Area")]
        public string MostVisited { get; set; }
        public enum Decks
        {
            UpperDeck = 1,
            LowerDeck = 2,
            MainDeck = 3
        }

        [Range(100, int.MaxValue, ErrorMessage = "Passenger must use complementary voucher of ${100}" )]
        
        [Display(Name = "Total Spent")]
        public double AmountSpent { get; set; }
    }
}
