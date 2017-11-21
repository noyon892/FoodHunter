using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.FoodHunterWeb.AppLayer.Helpers
{
    public class Facade
    {
        private readonly IRestaurantRepository _restaurantContext;
        private readonly IFoodRepository _foodContext;
        private readonly IReviewRepository _reviewContext;

        public Facade()
        {
            _restaurantContext = Factory.GetRestaurantRepository();
            _foodContext = Factory.GetFoodRepository();
            _reviewContext = Factory.GetReviewRepository();
        }

        public bool IsValidRestaurantAdmin(int userId, int restaurantId)
        {
            if (_restaurantContext.Get(restaurantId).UserId == userId)
            {
                return true;
            }
            return false;
        }

        public bool IsValidFoodAdmin(int userId, int foodId)
        {
            var restaurantId = _foodContext.Get(foodId).RestaurantId;
            if (restaurantId != null && IsValidRestaurantAdmin(userId, (int)restaurantId))
                return true;

            return false;
        }


        public double GetRestaurantRating(int id)
        {
            int totalRating = 0;
            List<Review> reviews = _reviewContext.GetAll()
                .Where(r => r.RestaurantId == id).ToList();

            foreach (Review review in reviews)
            {
                totalRating += review.Rating;
            }

            if (reviews.Count > 0)
                return Math.Round((double)totalRating / reviews.Count,2);

            return 0;
        }

        public double GetFoodRating(int id)
        {
            int totalRating = 0;
            List<Review> reviews = _reviewContext.GetAll()
                .Where(r => r.FoodId == id).ToList();

            foreach (Review review in reviews)
            {
                totalRating += review.Rating;
            }

            if (reviews.Count > 0)
                return Math.Round((double)totalRating / reviews.Count,2);

            return 0;
        }
    }
}