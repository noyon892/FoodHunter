using System.Collections.Generic;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    public interface IUserReposiroty
    {
        List<User> GetAll();
        User Get(int id);
        int Insert(User user);
        int Update(User user);
        int Delete(int id);
    }
}