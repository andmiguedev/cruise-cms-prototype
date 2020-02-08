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

        /**
         * Render a list of Cruise itineraries to be seen  
         * by any authorized User who register as Employee
         */  
        public async Task<IActionResult> Index()
        {
            return View(await _db.Itinerary.ToListAsync());
        }

        /**
         * Render a left aligned form with Itinerary info
         * distributed in labels and blank input tags to
         * be fill by General Manager who has Admin rights
         */ 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /**
         * Create a new itinerary by typing all required
         * fields. After Manager is redirected to Index 
         */ 
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

        /**
         * All the Itinerary information is displayed inside
         * the input tags to be reviewed before proceeding
         */ 
        [HttpGet]
        public async Task<IActionResult> Edit(int? ID)
        {
            var itineraryInfo = await _db.Itinerary.FindAsync(ID);

            if (ID == null && itineraryInfo == null)
            {
                return NotFound();
            }

            return View(itineraryInfo);
        }

        /**
         * Manager is able to modify Itinerary information 
         * in some circumstances. Important notice below:
         * 
         * Bug: Changing ALL property fields is required
         */ 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Itinerary itinerary)
        {
            if (ModelState.IsValid)
            {
                _db.Update(itinerary);

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(itinerary);
        }

        /**
         * Important itinerary information is displayed 
         * as a reminder that this action cannot be undo 
         */ 
        [HttpGet]
        public async Task<IActionResult> Delete(int? ID)
        {
            var catalogInfo = await _db.Itinerary.FindAsync(ID);

            if (ID == null && catalogInfo == null)
            {
                return NotFound();
            }

            return View(catalogInfo);
        }

        /**
         * Manager is able to remove an itinerary in rare
         * circumstances. For right now disabled fields 
         * are displayed. In the future a friendly modal
         * will alert the User to take action or exit.
         */ 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int ID)
        {
            var singleItinerary = await _db.Itinerary.FindAsync(ID);
            
            if (singleItinerary == null)
            {
                return NotFound();
            }

            _db.Itinerary.Remove(singleItinerary);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}