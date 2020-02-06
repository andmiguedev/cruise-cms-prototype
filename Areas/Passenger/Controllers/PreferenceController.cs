using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CruiseCMSDemo.Models.ViewModels;
using CruiseCMSDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CruiseCMSDemo.Areas.Passenger.Controllers
{
    [Area("Passenger")]
    public class PreferenceController : Controller
    {
        private readonly ApplicationDbContext _db;

        /* ViewModel can be used without passing as an
         * argument */
        [BindProperty]
        public PopulateEntitiesViewModel TravelInfo { get; set; }

        /*Initialize ViewModel objects to prevent null exception */
        public PreferenceController(ApplicationDbContext db)
        {
            _db = db;
            
            TravelInfo = new PopulateEntitiesViewModel()
            {
                Itinerary = _db.Itinerary,
                Preference = new Models.Preference()
                //Profile = _db.Profile
            };
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
        

        public IActionResult Create()
        {
            return View(TravelInfo);
        }








    }
}
