using System.Collections.Generic;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    public class RestaurantAdmin : User
    {
        internal RestaurantAdmin()
        {
            Type = UserType.RestaurantAdmin;
        }

        public List<Restaurant> Restaurants { get; set; }
    }
}
