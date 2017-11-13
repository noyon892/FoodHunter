using System.Data.Entity;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    public class DataContext : DbContext
    {
        private static DataContext Instance { get; set; }
        private DataContext(){}

        public static DataContext GetInstance()
        {
            return Instance ?? (Instance = new DataContext());
        }

        public DbSet<AppAdmin> AppAdmins { get; set; }
        public DbSet<RestaurantAdmin> RestaurantAdmins { get; set; }
        public DbSet<Foodie> Foodies { get; set; }
        public DbSet<Food> Foods { get; set; }  
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<News> Newses { get; set; }
    }
}
