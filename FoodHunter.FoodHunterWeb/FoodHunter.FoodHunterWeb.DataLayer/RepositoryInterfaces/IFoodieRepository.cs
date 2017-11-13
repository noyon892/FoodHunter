using System.Collections.Generic;
using FoodHunter.FoodHunterWeb.DataLayer;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    public interface IFoodieRepository
    {
        List<Foodie> GetAll();
        Foodie Get(int id);
        int Insert(Foodie foodie);
        int Update(Foodie foodie);
        int Delete(int id);
    }
}