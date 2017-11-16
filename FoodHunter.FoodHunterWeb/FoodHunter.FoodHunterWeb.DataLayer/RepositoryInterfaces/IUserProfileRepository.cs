using System.Collections.Generic;

namespace FoodHunter.Web.DataLayer
{
    public interface IUserProfileRepository
    {

        List<UserProfile> GetAll();
        UserProfile Get(int id);
        int Insert(UserProfile appAdmin);
        int Update(UserProfile appAdmin);
        int Delete(int id);
    }
}