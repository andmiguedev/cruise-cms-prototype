using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CruiseCMSDemo.Models;
using System.IO;
using CruiseCMSDemo.Models.ViewModels;
using CruiseCMSDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace CruiseCMSDemo.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            LandingPageViewModel bannerContent = new LandingPageViewModel()
            {
                Itinerary = await _db.Itinerary.ToListAsync(),
                Admin = await _db.Admin.ToListAsync()
            };

            return View(bannerContent);
        }









        public IActionResult Privacy()
        {
            return View();
        }


        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
