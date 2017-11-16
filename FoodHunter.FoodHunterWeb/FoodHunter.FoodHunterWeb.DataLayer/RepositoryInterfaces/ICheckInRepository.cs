using System.Collections.Generic;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.Web.DataLayer
{
    public interface ICheckInRepository
    {
        List<CheckIn> GetAll();
        CheckIn Get(int id);
        int Insert(CheckIn checkIn);
        int Update(CheckIn checkIn);
        int Delete(int id);
    }
}