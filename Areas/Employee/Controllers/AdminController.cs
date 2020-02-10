using System;
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
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                _db.Admin.Add(webAdmin);
                await _db.SaveChangesAsync();

                // Find the root Path of the Application
                string webRootPath = _hostingEnvironment.WebRootPath;

                // Store images that webAdmin has uploaded
                var files = HttpContext.Request.Form.Files;

                // Store information that webAdmin has fill
                var saveInfo = await _db.Admin.FirstAsync();

                if (files.Count > 0)
                {
                    // Admin has uploaded a background Image
                    var uploads = Path.Combine(webRootPath, "img");

                    // Append extension to the Image uploaded
                    var extension = Path.GetExtension(files[0].FileName);


                    using (var fileStream = new FileStream(Path.Combine(uploads, 
                        webAdmin.Id + extension), FileMode.Create ))
                    {
                        // Copy Background image to "img" folder 
                        // and rename it
                        files[0].CopyTo(fileStream);
                    }

                    // Save background image with extension
                    saveInfo.Image = @"\img\" + webAdmin.Id + extension;
                }
                else
                {
                    // Use default Background image
                    // if no picture was selected
                    var uploads = Path.Combine(webRootPath, @"img\" + StaticAssets.DefaultBackground);

                    // Make a temporary Copy to the "img" folder
                    System.IO.File.Copy(uploads, webRootPath + @"\img\" + webAdmin.Id + ".png");

                    // Update Admin object with background Image
                    webAdmin.Image = @"\img\" + webAdmin.Id + ".png";
                }

                // Update the database with new webAdmin
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
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
        public async Task<IActionResult> Edit(Admin webAdmin, int ID)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                _db.Admin.Add(webAdmin);
                await _db.SaveChangesAsync();

                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                var saveInfo = await _db.Admin.FirstAsync();

                if (files.Count > 0)
                {
                    // Upload a new selected Background Image 
                    var uploads = Path.Combine(webRootPath, "img");
                    var newExtension = Path.GetExtension(files[0].FileName);

                    // Remove older Path where the Image was stored
                    var imagePath = Path.Combine(webRootPath, webAdmin.Image.TrimStart('\\'));

                    // Check if Background image exists
                    if (System.IO.File.Exists(imagePath))
                    {
                        // Remove the Image from Server
                        System.IO.File.Delete(imagePath);
                    }

                    // Replace Background with new Image
                    using (var fileStream = new FileStream(Path.Combine(uploads,
                        webAdmin.Id + newExtension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    // Save path of new Background Image
                    saveInfo.Image = @"\img\" + webAdmin.Id + newExtension;
                }
            }

            // If Admin has changed other fields
            var singleAdmin = await _db.Admin.FindAsync(ID);

            // Update property fields in the Database
            singleAdmin.Username = singleAdmin.Username;
            singleAdmin.Password = singleAdmin.Password;
            singleAdmin.EmailAddress = singleAdmin.EmailAddress;
            singleAdmin.Description = singleAdmin.Description;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}