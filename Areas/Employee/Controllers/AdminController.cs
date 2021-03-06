﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using CruiseCMSDemo.Data;
using System.IO;
using CruiseCMSDemo.Models.ViewModels;
using CruiseCMSDemo.Utility;
using CruiseCMSDemo.Models;

namespace CruiseCMSDemo.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AdminController(ApplicationDbContext db, IWebHostEnvironment hostingEnvironment)
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
            var webAdmins = await _db.Admin.ToListAsync();
            return View(webAdmins);
        }

        /**
         * Render the Administrator form information
         * and the input fields that webmaster needs
         * to change the content in the Home page.
         */ 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /**
         * Create a new WebAdmin that has the capability
         * of changing content of the Website dynamically
         */ 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Admin webAdmin)
        {
            if (ModelState.IsValid)
            {
                // Store images that webAdmin has uploaded
                var pictures = HttpContext.Request.Form.Files;

                if (pictures.Count > 0)
                {
                    byte[] bannerImage = null;

                    // Read the picture that Admin selects
                    using (var fileStream = pictures[0].OpenReadStream())
                    {
                        // Convert picture into stream of bytes and 
                        // stored into bannerImage 
                        using (var memoryStream = new MemoryStream())
                        {
                            fileStream.CopyTo(memoryStream);
                            bannerImage = memoryStream.ToArray(); 
                        }
                    }

                    // Assign byte picture into Image
                    // property
                    webAdmin.Image = bannerImage;
                }

                _db.Admin.Add(webAdmin);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(webAdmin);
        }

        /**
         * Render Web Administrator information, and display 
         * existing Background image and slogan description
         */ 
        [HttpGet]
        public async Task<IActionResult> Edit(int? ID)
        {
            var singleAdmin = await _db.Admin.SingleOrDefaultAsync(
                a => a.Id == ID);

            if (ID == null && singleAdmin == null)
            {
                return NotFound();
            }

            return View(singleAdmin);
        }

         /**
         * Registered Web Administrator can now update 
         * information on the Website Banner section
         */ 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, Admin webAdmin)
        {

            // If Admin has changed other fields
            var singleAdmin = await _db.Admin.FindAsync(Id);

            if (ModelState.IsValid)
            {
                // Store images that webAdmin has uploaded
                var pictures = HttpContext.Request.Form.Files;

                if (pictures.Count > 0)
                {
                    byte[] bannerImage = null;

                    using (var fileStream = pictures[0].OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            fileStream.CopyTo(memoryStream);
                            bannerImage = memoryStream.ToArray(); 
                        }
                    }

                    webAdmin.Image = bannerImage;
                }

                // Update property fields in the Database
                singleAdmin.Username = singleAdmin.Username;
                singleAdmin.Password = singleAdmin.Password;
                singleAdmin.EmailAddress = singleAdmin.EmailAddress;
                singleAdmin.Description = singleAdmin.Description;

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(webAdmin);    
        }

         /**
         * Display General Information of each Website
         * Administrator to be reviewed before removal
         */ 
        [HttpGet]
        public async Task<IActionResult> Delete(int? ID)
        {
            var findAdmin = await _db.Admin.SingleOrDefaultAsync(
                a => a.Id == ID);

            if (ID == null && findAdmin == null)
            {
                return NotFound();
            }

            return View(findAdmin);
        }

         /**
         * Manager is able to remove an Administrator. 
         * In the future, He or she will be disabled
         * from having access to the Dashboard.
         * 
         * Note: Manager has not been implemented yet
         */ 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int ID)
        {
            var removeAdmin = await _db.Admin.SingleOrDefaultAsync(
                a => a.Id == ID);

            _db.Admin.Remove(removeAdmin);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}