using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using CruiseCMSDemo.Data;

namespace CruiseCMSDemo.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AdminController(ApplicationDbContext db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        /**
         * Render a list of selected Administrators. One 
         * of them is in charge of updating the banner 
         * image and description on the Home page.
         */ 
        public async Task<IActionResult> Index()
        {
            var webmaster = await _db.Administrator.ToListAsync();

            return View(webmaster);
        }
    }
}