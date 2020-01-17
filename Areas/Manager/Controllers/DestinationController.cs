using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CruiseCMSDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CruiseCMSDemo.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class DestinationController : Controller
    {
       /**
        * Microsoft recommendation to use async await
        * when returning a primitive or complex type.
        * 
        * For more information, browse docs, under
        * Specific type
        * 
        * https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-3.1 
        */
        private readonly ApplicationDbContext _db;
        public DestinationController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET /destination/caribbean/bahamas?id=053512
        public async Task<IActionResult> Index()
        {
            return View(await _db.Destination.ToListAsync());
        }


    }
}