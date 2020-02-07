using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CruiseCMSDemo.Models.ViewModels;
using CruiseCMSDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CruiseCMSDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CruiseCMSDemo.Areas.Passenger.Controllers
{
    [Area("Passenger")]
    public class PreferenceController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PreferenceController(ApplicationDbContext db)
        {
            _db = db;
        }

        /**
        * Render a list of Passenger preferences that are
        * available to all kinds of employees. Only Users
        * can perform CRUD tasks in their own Preference 
        */
        public async Task<IActionResult> Index()
        {
            var preferences = await _db.Preference.Include(
                p => p.Profile).Include(p => p.Itinerary).ToListAsync();
            
            return View(preferences);
        }

        /**
         * Create a new Profile by filling passenger choice
         * when it comes to services during the Cruise sail
         * Planning to display Profile object as a menu list.
         * Currently unable to achieve that using JavaScript
         */
        public async Task<IActionResult> Create()
        {
            PassengerViewModel travelInfo = new PassengerViewModel()
            {
                ProfileNames = await _db.Profile.ToListAsync(),
                DestinationList = await _db.Itinerary.ToListAsync(),
                Preference = new Models.Preference()
            };

            return View(travelInfo);
        }







        
        
    }
}