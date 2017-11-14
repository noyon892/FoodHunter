using System.Collections.Generic;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    public class RestaurantAdmin : Profile
    {
        public List<Restaurant> Restaurants { get; set; }
    }
}
