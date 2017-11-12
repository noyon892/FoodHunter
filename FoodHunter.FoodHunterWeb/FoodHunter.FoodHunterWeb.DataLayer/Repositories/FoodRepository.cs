using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FoodHunter.FoodHunterWeb.DataLayer;
using FoodHunter.FoodHunterWeb.DataLayer.ModelClasses;
using FoodHunter.FoodHunterWeb.DataLayer.RepositoryInterfaces;

namespace FoodHunter.FoodHunterWeb.DataLayer.Repositories
{
    public class FoodRepository : IFoodRepository
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
            Review foodToUpdate = _context.Reviews.SingleOrDefault(e => e.ReviewId == food.FoodId);
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
