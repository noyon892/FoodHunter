using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.Web.DataLayer
{
    class FoodieRepository : IFoodieRepository
    {
        private readonly DataContext _context;

        public FoodieRepository()
        {
            _context = new DataContext();
        }

        public List<Foodie> GetAll()
        {
            return _context.Foodies.ToList();
        }

        public Foodie Get(int id)
        {
            return _context.Foodies.SingleOrDefault(e => e.UserId == id);
        }

        public int Insert(Foodie foodie)
        {
            this._context.Foodies.Add(foodie);

            return this._context.SaveChanges();
        }

        public int Update(Foodie foodie)
        {
            Foodie foodieToUpdate = (Foodie)_context.Foodies.SingleOrDefault(e => e.UserId == foodie.UserId);
            foreach (PropertyInfo property in typeof(Foodie).GetProperties())
            {
                property.SetValue(foodieToUpdate, property.GetValue(foodie, null), null);
            }

            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            Foodie foodieToDelete = _context.Foodies.SingleOrDefault(e => e.UserId == id);
            if(foodieToDelete != null) _context.Foodies.Remove(foodieToDelete);

            return _context.SaveChanges();
        }
    }
}
