using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using CruiseCMSDemo.Data;
using CruiseCMSDemo.Models;
using System.IO;
using CruiseCMSDemo.Models.ViewModels;

namespace CruiseCMSDemo.Areas.Manager.Controllers
{
    [Area("Employee")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;

        [BindProperty]
        public EmployeeViewModel webAdmin { get; set; }

        public AdminController(ApplicationDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;

            webAdmin = new EmployeeViewModel()
            {
                Personnel = _db.Personnel,
                Admin = new Models.Administrator()
            };
        }

        /**
         * Render a list of selected Administrators. One 
         * of them is in charge of updating the banner 
         * image and description on the Home page.
         */ 
        public async Task<IActionResult> Index()
        {
            var displayAdmins = await _db.Administrator.Include
                (a => a.Employee).ToListAsync();

            return View(displayAdmins);
        }

        /**
         * Render the Administrator form information
         * and the input fields that webmaster needs
         * to change the content in the Home page.
         */ 
        [HttpGet]
        public IActionResult Create()
        {
            return View(webAdmin);
        }
    }
}