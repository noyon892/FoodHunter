namespace FoodHunter.Web.DataLayer
{
    public class Factory
    {
        public static IUserReposiroty GetUserReposiroty() { return new UserRepository();}
        public static IUserProfileRepository GetUserProfileRepository(){ return new UserProfileRepository(); }
        public static IFoodRepository GetFoodRepository() { return new FoodRepository();}
        public static IRestaurantRepository GetRestaurantRepository() { return new RestaurantRepository();}
        public static IReviewRepository GetReviewRepository() { return new ReviewRepository();}
        public static ICheckInRepository GetCheckInRepository() { return new CheckInRepository();}
        public static INewsRepository GetNewsRepository() { return new NewsRepository();}

    }
}
