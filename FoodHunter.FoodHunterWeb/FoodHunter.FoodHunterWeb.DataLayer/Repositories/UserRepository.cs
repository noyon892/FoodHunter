using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FoodHunter.FoodHunterWeb.DataLayer;
using FoodHunter.FoodHunterWeb.DataLayer.ModelClasses;
using FoodHunter.FoodHunterWeb.DataLayer.RepositoryInterfaces;

namespace FoodHunter.FoodHunterWeb.DataLayer.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository()
        {
            _context = new DataContext();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Get(int id)
        {
            return _context.Users.SingleOrDefault(e => e.UserId == id);
        }

        public int Insert(User user)
        {
            this._context.Users.Add(user);

            return this._context.SaveChanges();
        }

        public int Update(User user)
        {
            User userToUpdate = _context.Users.SingleOrDefault(e => e.UserId == user.UserId);
            foreach (PropertyInfo property in typeof(User).GetProperties())
            {
                property.SetValue(userToUpdate, property.GetValue(user, null), null);
            }

            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            User userToDelete = _context.Users.SingleOrDefault(e => e.UserId == id);
            if(userToDelete != null) _context.Users.Remove(userToDelete);

            return _context.SaveChanges();
        }
    }
}
