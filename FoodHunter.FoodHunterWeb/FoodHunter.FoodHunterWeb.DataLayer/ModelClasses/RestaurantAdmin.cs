using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHunter.FoodHunterWeb.DataLayer.ModelClasses
{
    public class RestaurantAdmin : User
    {
        public RestaurantAdmin()
        {
            Type = UserType.RestaurantAdmin;
        }

        public List<Restaurant> Restaurants { get; set; }
    }
}
