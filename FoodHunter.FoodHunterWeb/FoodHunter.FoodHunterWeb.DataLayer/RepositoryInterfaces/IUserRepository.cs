using System.Collections.Generic;

namespace FoodHunter.Web.DataLayer
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