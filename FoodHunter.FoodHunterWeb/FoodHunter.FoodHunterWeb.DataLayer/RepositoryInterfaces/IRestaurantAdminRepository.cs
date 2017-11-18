using System.Collections.Generic;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.Web.DataLayer
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