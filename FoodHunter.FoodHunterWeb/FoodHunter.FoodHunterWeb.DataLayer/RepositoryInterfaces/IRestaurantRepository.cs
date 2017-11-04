using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHunter.FoodHunterWeb.DataLayer.ModelClasses;

namespace FoodHunter.FoodHunterWeb.DataLayer.RepositoryInterfaces
{
    interface IRestaurantRepository
    {
        List<Restaurant> GetAll();
        Restaurant Get(int id);
        int Insert(Restaurant restaurant);
        int Update(Restaurant restaurant);
        int Delete(int id);
    }
}
