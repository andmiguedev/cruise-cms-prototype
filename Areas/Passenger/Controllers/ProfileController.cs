using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CruiseCMSDemo.Data;
using CruiseCMSDemo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CruiseCMSDemo.Areas.Passenger.Controllers
{
    [Area("Passenger")]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; }

        public ProfileController(ApplicationDbContext db)
        {
            _db = db;
        }


        /**
         * Render a list of Cruise passengers to be seen
         * by employees only. It cannot have CRUD tasks
         */
        public async Task<IActionResult> Index()
        {
            var onlineProfiles = await _db.Profile.Include(
                p => p.Itinerary).ToListAsync();

            return View(onlineProfiles);
        }

        /**
         * Render a row-form based form with the properties
         * of a Passenger, and a list of recent destinations
         */
        public async Task<IActionResult> Create()
        {
            PassengerViewModel passenger = new PassengerViewModel()
            {
                DestinationList = await _db.Itinerary.ToListAsync(),
                Profile = new Models.Profile(),
            };

            return View(passenger);
        }


        /**
         * Create a new Profile by filling out the Registration
         * information. Also a dropdown list for Destinations are
         * given. Validation is applied only for Email right now.
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PassengerViewModel passenger)
        {
            if (ModelState.IsValid)
            {
                var emailExists = _db.Profile.Include(
                    p => p.Itinerary).Where(
                    p => p.Email == passenger.Profile.Email);

                if(emailExists.Count() > 0)
                {
                    ErrorMessage = "Warning: This Form simulates a User that register to this site. " +
                                   emailExists.First().Email + " already exists in the system!";                
                }
                else
                {
                    _db.Profile.Add(passenger.Profile);
                    await _db.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }

            PassengerViewModel addProfile = new PassengerViewModel()
            {
                DestinationList = await _db.Itinerary.ToListAsync(),
                Profile = passenger.Profile,
                ErrorMessage = ErrorMessage
            };

            return View(addProfile);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            var singleProfile = await _db.Profile.SingleOrDefaultAsync(
               p => p.Id == id);

            if (id == null && singleProfile == null)
                return NotFound();

            PassengerViewModel passenger = new PassengerViewModel()
            {
                DestinationList = await _db.Itinerary.ToListAsync(),
                Profile = singleProfile,
            };

            return View(passenger);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, PassengerViewModel passenger)
        {
            if (ModelState.IsValid)
            {
                var singleProfile = await _db.Profile.FindAsync(Id);

                singleProfile.Address = passenger.Profile.Address;
                singleProfile.City = passenger.Profile.City;
                singleProfile.State = passenger.Profile.State;
                singleProfile.ZipCode = passenger.Profile.ZipCode;
                singleProfile.Email = passenger.Profile.Email;
                singleProfile.Phone = passenger.Profile.Phone;

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PassengerViewModel updateProfile = new PassengerViewModel()
            {
                DestinationList = await _db.Itinerary.ToListAsync(),
                Profile = passenger.Profile,
            };

            return View(updateProfile);
        }
    }
}