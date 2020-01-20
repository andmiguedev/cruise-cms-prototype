using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CruiseCMSDemo.Data;
using CruiseCMSDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CruiseCMSDemo.Areas.Customer.Controllers
{
    [Area("Passenger")]
    public class ItineraryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItineraryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Itinerary.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Itinerary itinerary)
        {
            if (ModelState.IsValid)
            {
                _db.Itinerary.Add(itinerary);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(itinerary);
        }


    }
}