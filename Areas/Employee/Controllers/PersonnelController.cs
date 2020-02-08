using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CruiseCMSDemo.Data;
using CruiseCMSDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CruiseCMSDemo.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class PersonnelController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PersonnelController(ApplicationDbContext db)
        {
            _db = db;
        }

        /**
         * Render a list of important information for
         * Cruise employees that managers keep track
         */
        public async Task<IActionResult> Index()
        {
            return View(await _db.Personnel.ToListAsync());
        }
    }
}