using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHunter.FoodHunterWeb.DataLayer.ModelClasses;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }  
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
