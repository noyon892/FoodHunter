
namespace FoodHunter.Web.DataLayer
{
    public class Factory
    {
        public static IUserRepository GetUserReposiroty() { return new UserRepository();}
        public static IFoodieRepository GetFoodieRepository(){ return new FoodieRepository(); }
        public static IRestaurantAdminRepository GetRestaurantAdminRepository() { return new RestaurantAdminRepository();}
        public static IAppAdminRepository GetAppAdminRepository() { return new AppAdminRepository();}
        public static IFoodRepository GetFoodRepository() { return new FoodRepository();}
        public static IRestaurantRepository GetRestaurantRepository() { return new RestaurantRepository();}
        public static IReviewRepository GetReviewRepository() { return new ReviewRepository();}
        public static ICheckInRepository GetCheckInRepository() { return new CheckInRepository();}
        public static INewsRepository GetNewsRepository() { return new NewsRepository();}

    }
}
