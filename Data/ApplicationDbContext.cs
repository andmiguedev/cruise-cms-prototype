using System;
using System.Collections.Generic;
using System.Text;
using CruiseCMSDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CruiseCMSDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /**
         * Create migrations for Models that are 
         * used in Dashboard pages and Landing page
         */ 
        public DbSet<Itinerary> Itinerary { get; set; }
        public DbSet<Profile> Profile { get; set; }

        public DbSet<Administrator> Administrator { get; set; }
    }
}
