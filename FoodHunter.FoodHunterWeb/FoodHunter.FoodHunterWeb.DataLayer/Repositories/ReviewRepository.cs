using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FoodHunter.FoodHunterWeb.DataLayer;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    class ReviewRepository :  IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository()
        {
            _context = DataContext.GetInstance();
        }

        public List<Review> GetAll()
        {
            return _context.Reviews.ToList();
        }

        public Review Get(int id)
        {
            return _context.Reviews.SingleOrDefault(e => e.ReviewId == id);
        }

        public int Insert(Review review)
        {
            this._context.Reviews.Add(review);

            return _context.SaveChanges();
        }

        public int Update(Review review)
        {
            Review reviewToUpdate = _context.Reviews.SingleOrDefault(e => e.ReviewId == review.ReviewId);
            foreach (PropertyInfo property in typeof(CheckIn).GetProperties())
            {
                property.SetValue(reviewToUpdate, property.GetValue(review, null), null);
            }

            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            Review reviewToDelete = _context.Reviews.SingleOrDefault(e => e.ReviewId == id);
            if (reviewToDelete != null) _context.Reviews.Remove(reviewToDelete);

            return _context.SaveChanges();
        }
    }
}
