using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CruiseCMSDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
         * 
         */ 
        public async Task<IActionResult> Index()
        {
            var preferences = await _db.Preference.Include(
                p => p.Profile).Include(p => p.Itinerary).ToListAsync();
            
            return View(preferences);
        }
    }
}