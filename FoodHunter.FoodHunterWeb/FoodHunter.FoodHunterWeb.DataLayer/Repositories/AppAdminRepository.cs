using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FoodHunter.FoodHunterWeb.DataLayer;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    class AppAdminRepository : IAppAdminRepository
    {
        private readonly DataContext _context;

        public AppAdminRepository()
        {
            _context = DataContext.GetInstance();
        }

        public List<AppAdmin> GetAll()
        {
            return _context.AppAdmins.ToList();
        }

        public AppAdmin Get(int id)
        {
            return _context.AppAdmins.SingleOrDefault(e => e.UserId == id);
        }

        public int Insert(AppAdmin appAdmin)
        {
            this._context.AppAdmins.Add(appAdmin);

            return this._context.SaveChanges();
        }

        public int Update(AppAdmin appAdmin)
        {
            AppAdmin userToUpdate = _context.AppAdmins.SingleOrDefault(e => e.UserId == appAdmin.UserId);
            foreach (PropertyInfo property in typeof(AppAdmin).GetProperties())
            {
                property.SetValue(userToUpdate, property.GetValue(appAdmin, null), null);
            }

            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            AppAdmin appAdminToDelete = _context.AppAdmins.SingleOrDefault(e => e.UserId == id);
            if(appAdminToDelete != null) _context.AppAdmins.Remove(appAdminToDelete);

            return _context.SaveChanges();
        }
    }
}
