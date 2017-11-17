using System.Collections.Generic;

namespace FoodHunter.Web.DataLayer
{
    public interface IFoodieRepository
    {

        List<Foodie> GetAll();
        Foodie Get(int id);
        int Insert(Foodie appAdmin);
        int Update(Foodie appAdmin);
        int Delete(int id);
    }
}