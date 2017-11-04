using System.Collections.Generic;
using FoodHunter.FoodHunterWeb.DataLayer.ModelClasses;

namespace FoodHunter.FoodHunterWeb.DataLayer.RepositoryInterfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Get(int id);
        int Insert(User user);
        int Update(User user);
        int Delete(int id);
    }
}