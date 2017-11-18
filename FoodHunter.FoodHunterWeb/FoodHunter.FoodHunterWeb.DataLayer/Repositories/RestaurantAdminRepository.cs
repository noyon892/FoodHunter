using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    class RestaurantAdminRepository : IRestaurantAdminRepository
    {
        private readonly DataContext _context;
        public RestaurantAdminRepository()
        {
            _context = new DataContext();
        }

        public List<RestaurantAdmin> GetAll()
        {
            return _context.RestaurantAdmins.ToList();
        }

        public RestaurantAdmin Get(int id)
        {
            return _context.RestaurantAdmins.SingleOrDefault(e => e.UserId == id);
        }

        public int Insert(RestaurantAdmin restaurantAdmin)
        {
            _context.RestaurantAdmins.Add(restaurantAdmin);

            return _context.SaveChanges();
        }

        public int Update(RestaurantAdmin restaurantAdmin)
        {
            RestaurantAdmin restaurantAdminToUpdate = _context.RestaurantAdmins.SingleOrDefault(e => e.UserId == restaurantAdmin.UserId);
            foreach (PropertyInfo property in typeof(RestaurantAdmin).GetProperties())
            {
                property.SetValue(restaurantAdminToUpdate, property.GetValue(restaurantAdmin, null), null);
            }

            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            RestaurantAdmin restaurantAdminToDelete = _context.RestaurantAdmins.SingleOrDefault(e => e.UserId == id);
            if (restaurantAdminToDelete != null) _context.RestaurantAdmins.Remove(restaurantAdminToDelete);

            return _context.SaveChanges();
        }
    }
}