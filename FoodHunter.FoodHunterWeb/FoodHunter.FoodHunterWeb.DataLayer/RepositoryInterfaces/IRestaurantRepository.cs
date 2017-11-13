using System.Collections.Generic;
using FoodHunter.FoodHunterWeb.DataLayer;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    public interface IRestaurantRepository
    {
        List<Restaurant> GetAll();
        Restaurant Get(int id);
        int Insert(Restaurant restaurant);
        int Update(Restaurant restaurant);
        int Delete(int id);
    }
}
