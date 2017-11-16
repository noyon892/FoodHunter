using System.Collections.Generic;

namespace FoodHunter.Web.DataLayer
{
    public class RestaurantAdmin : UserProfile
    {
        public List<Restaurant> Restaurants { get; set; }
    }
}
