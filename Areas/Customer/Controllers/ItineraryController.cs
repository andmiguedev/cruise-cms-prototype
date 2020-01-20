using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CruiseCMSDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CruiseCMSDemo.Areas.Customer.Controllers
{
    [Area("Customer")]
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


    }
}