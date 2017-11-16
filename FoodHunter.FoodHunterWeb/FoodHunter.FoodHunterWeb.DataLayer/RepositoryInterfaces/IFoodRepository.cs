using System.Collections.Generic;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.Web.DataLayer
{
    public interface IFoodRepository
    {
        List<Food> GetAll();
        Food Get(int id);
        int Insert(Food food);
        int Update(Food food);
        int Delete(int id);
    }
}
