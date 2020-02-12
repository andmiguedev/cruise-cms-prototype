using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseCMSDemo.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 5)]
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Country { get; set; }

        [Display(Name = "Recent Place")]
        public int ItineraryId { get; set; }

        [ForeignKey("ItineraryId")]
        public virtual Itinerary Itinerary { get; set; }

        [Display(Name = "Street Address")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$")]
        public int ZipCode { get; set; }

        [Display(Name = "Contact Number")]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$")]
        [StringLength(12)]
        [Required]
        public string Phone { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Are you a Resident?")]
        public bool isLocal { get; set; }
    }   
}
