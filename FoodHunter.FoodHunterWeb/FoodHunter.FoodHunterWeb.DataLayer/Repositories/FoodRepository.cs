using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.Web.DataLayer
{
    class FoodRepository : IFoodRepository
    {
        private readonly DataContext _context;

        public FoodRepository()
        {
            _context = new DataContext();
        }

        public List<Food> GetAll()
        {
            return _context.Foods.ToList();
        }

        public Food Get(int id)
        {
            return _context.Foods.SingleOrDefault(e => e.FoodId == id);
        }

        public int Insert(Food food)
        {
            this._context.Foods.Add(food);

            return _context.SaveChanges();
        }

        public int Update(Food food)
        {
            Food foodToUpdate = _context.Foods.SingleOrDefault(e => e.FoodId == food.FoodId);
            foreach (PropertyInfo property in typeof(Food).GetProperties())
            {
                property.SetValue(foodToUpdate, property.GetValue(food, null), null);
            }

            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            Food foodToDelete = _context.Foods.SingleOrDefault(e => e.FoodId == id);
            if (foodToDelete != null) _context.Foods.Remove(foodToDelete);

            return _context.SaveChanges();
        }
    }
}
