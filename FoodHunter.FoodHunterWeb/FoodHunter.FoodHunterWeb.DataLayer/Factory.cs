using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHunter.FoodHunterWeb.DataLayer.Repositories;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    public class Factory
    {
        public static IUserReposiroty UserReposiroty() { return new UserRepository();}
        public static IAppAdminRepository GetAdminRepository(){ return new AppAdminRepository(); }
        public static IRestaurantAdminRepository GetRestaurantAdminRepository() { return new RestaurantAdminRepository();}
        public static IFoodieRepository GetFoodieRepository() { return new FoodieRepository();}
        public static IFoodRepository GetFoodRepository() { return new FoodRepository();}
        public static IRestaurantRepository GetRestaurantRepository() { return new RestaurantRepository();}
        public static IReviewRepository GetReviewRepository() { return new ReviewRepository();}
        public static ICheckInRepository GetCheckInRepository() { return new CheckInRepository();}
        public static INewsRepository GetNewsRepository() { return new NewsRepository();}

    }
}
