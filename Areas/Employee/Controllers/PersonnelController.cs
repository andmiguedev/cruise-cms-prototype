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

        /**
         * Render a registration form with personal info
         * and Staff working responsabilties on the Ship
         */
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /**
         * Create a new employee in the category of staff.
         * This form includes two enum for multiple choices
         */ 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Personnel staff)
        {
            if (ModelState.IsValid)
            {
                _db.Personnel.Add(staff);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(staff);
        }

        /**
         * All the Staff employee info is displayed inside
         * the input tags to be reviewed before proceeding
         */
        public async Task<IActionResult> Edit(int? Id)
        {
            var staffInfo = await _db.Personnel.FindAsync(Id);

            if (Id == null && staffInfo == null)
            {
                return NotFound();
            }

            return View(staffInfo);
        }

        /**
         * Each staff employee is able to make changes 
         * to his or her own information in the form.
         * All fields MUST be changed in order to Edit
         */ 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Personnel staff)
        {
            if (ModelState.IsValid)
            {
                _db.Update(staff);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(staff);
        }

        /**
         * Managers can see brief information of each
         * Staff employee. They have at least 3 years
         * of experience in the Company to be Staff.
         */ 
        public async Task<IActionResult> Details(int? id)
        {
             var singleEmployee = await _db.Personnel.FindAsync(id);

            if (id == null && singleEmployee == null)
            {
                return NotFound();
            }

            return View(singleEmployee);
        }
    }
}