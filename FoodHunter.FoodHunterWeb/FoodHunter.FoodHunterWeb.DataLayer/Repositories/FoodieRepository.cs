using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    class FoodieRepository : IFoodieRepository
    {
        private readonly DataContext _context;
        public FoodieRepository()
        {
            _context = DataContext.GetInstance();
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
            _context.Foodies.Add(foodie);

            return _context.SaveChanges();
        }

        public int Update(Foodie foodie)
        {
            Foodie foodieToUpdate = _context.Foodies.SingleOrDefault(e => e.UserId == foodie.UserId);
            foreach (PropertyInfo property in typeof(Foodie).GetProperties())
            {
                property.SetValue(foodieToUpdate, property.GetValue(foodieToUpdate, null), null);
            }

            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            Foodie foodieToDelete = _context.Foodies.SingleOrDefault(e => e.UserId == id);
            if (foodieToDelete != null) _context.Foodies.Remove(foodieToDelete);

            return _context.SaveChanges();
        }
    }
}
