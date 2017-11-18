using System.Collections.Generic;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.Web.DataLayer
{
    public interface IAppAdminRepository
    {

        List<AppAdmin> GetAll();
        AppAdmin Get(int id);
        int Insert(AppAdmin appAdmin);
        int Update(AppAdmin appAdmin);
        int Delete(int id);
    }
}