using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.Web.DataLayer
{
    class UserProfileRepository : IUserProfileRepository
    {
        private readonly DataContext _context;

        public UserProfileRepository()
        {
            _context = new DataContext();
        }

        public List<UserProfile> GetAll()
        {
            return _context.UserProfiles.ToList();
        }

        public UserProfile Get(int id)
        {
            return _context.UserProfiles.SingleOrDefault(e => e.UserId == id);
        }

        public int Insert(UserProfile userProfile)
        {
            this._context.UserProfiles.Add(userProfile);

            return this._context.SaveChanges();
        }

        public int Update(UserProfile userProfile)
        {
            UserProfile userProfileToUpdate = (UserProfile)_context.UserProfiles.SingleOrDefault(e => e.UserId == userProfile.UserId);
            foreach (PropertyInfo property in typeof(UserProfile).GetProperties())
            {
                property.SetValue(userProfileToUpdate, property.GetValue(userProfile, null), null);
            }

            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            UserProfile userProfileToDelete = _context.UserProfiles.SingleOrDefault(e => e.UserId == id);
            if(userProfileToDelete != null) _context.UserProfiles.Remove(userProfileToDelete);

            return _context.SaveChanges();
        }
    }
}
