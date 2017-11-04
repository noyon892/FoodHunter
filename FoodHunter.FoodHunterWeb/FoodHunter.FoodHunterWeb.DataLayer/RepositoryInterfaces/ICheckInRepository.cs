using System.Collections.Generic;
using FoodHunter.FoodHunterWeb.DataLayer.ModelClasses;

namespace FoodHunter.FoodHunterWeb.DataLayer.RepositoryInterfaces
{
    public interface ICheckInRepository
    {
        List<CheckIn> GetAll();
        CheckIn Get(int id);
        int Insert(CheckIn food);
        int Update(CheckIn food);
        int Delete(int id);
    }
}