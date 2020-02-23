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
        /**
         * Use dependency injection to temporarily store
         * DefaultConnection string in appsettings.json
         */ 
        private readonly ApplicationDbContext _db;

        /* Constructor that globally assigns a variable
         * that can be used by all the other methods */
        public ItineraryController(ApplicationDbContext db)
        {
            _db = db;
        }

        /**
         * Get all the objects stored using DbContext 
         * for Itinerary and convert it to async List.
         * 
         * Note: async/await is used because we are 
         * dealing with more than one object at the 
         * same time.
         */  
        public async Task<IActionResult> Index()
        {
            return View(await _db.Itinerary.ToListAsync());
        }


        /**
         * Make a HTTP GET request to retrieve the 
         * properties that belong to an Itinerary,
         * then pass it to the Create View page
         */ 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /**
         * Make a HTTP POST request to create new
         * Itinerary objects to the database. 
         * 
         * As the parameter, pass the instance of 
         * the Itinerary Model that will allow us
         * to store new values for all the props.
         * 
         * Using the Add method we can use our db
         * variable to create an Itinerary object,
         * then save and store the changes in Db.
         * 
         * Finally, redirect User to the Index page
         * where all the Itineraries are displayed
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
         * Make a HTTP GET request to fetch all the 
         * information for that particular Itinerary.
         * 
         * Using the Find method we can grab all the
         * properties that are stored by passing the
         * primary key of each table.
         * 
         * Check if Itinerary ID nor the variable we
         * created does not exist before we render it 
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
         * Make a HTTP POST request to edit an existing 
         * Itinerary object in the database. Pass the 
         * same parameter as the Create function.
         * 
         * For this case, use Update method to edit all
         * the properties that belong to each Itinerary.
         * Then save and store all the changes in the Db
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
         * Make a HTTP Get request to render some or 
         * all the Itinerary information in read only
         * mode. So that User can check before delete
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
         * Make a HTTP POST request to remove a record
         * from the Itinerary table. 
         * 
         * Using the Remove method we can delete that
         * object by finding its corresponsing ID, then
         * save and store the changes in the database.
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