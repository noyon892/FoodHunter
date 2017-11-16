using System.Data.Entity;

namespace FoodHunter.Web.DataLayer
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Food> Foods { get; set; }  
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<News> Newses { get; set; }
    }
}
