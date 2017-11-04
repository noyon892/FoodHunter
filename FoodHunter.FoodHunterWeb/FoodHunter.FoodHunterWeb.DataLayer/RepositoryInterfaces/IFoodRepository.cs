using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHunter.FoodHunterWeb.DataLayer.ModelClasses;

namespace FoodHunter.FoodHunterWeb.DataLayer.RepositoryInterfaces
{
    interface IFoodRepository
    {
        List<Food> GetAll();
        Food Get(int id);
        int Insert(Food food);
        int Update(Food food);
        int Delete(int id);
    }
}
