using System.Collections.Generic;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.Web.DataLayer
{
    public interface IReviewRepository
    {
        List<Review> GetAll();
        Review Get(int id);
        int Insert(Review review);
        int Update(Review review);
        int Delete(int id);
    }
}
