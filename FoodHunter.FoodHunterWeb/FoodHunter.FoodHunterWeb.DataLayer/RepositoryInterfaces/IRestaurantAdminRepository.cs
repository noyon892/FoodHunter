using System.Collections.Generic;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    public interface IRestaurantAdminRepository
    {

        List<RestaurantAdmin> GetAll();
        RestaurantAdmin Get(int id);
        int Insert(RestaurantAdmin restaurantAdmin);
        int Update(RestaurantAdmin restaurantAdmin);
        int Delete(int id);
    }
}
