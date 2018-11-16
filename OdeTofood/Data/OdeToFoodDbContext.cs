using Microsoft.EntityFrameworkCore;
using OdeTofood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeTofood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext( DbContextOptions options )
            : base( options )
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
