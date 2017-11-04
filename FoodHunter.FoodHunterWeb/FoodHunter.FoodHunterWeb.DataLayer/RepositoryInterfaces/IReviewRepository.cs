using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHunter.FoodHunterWeb.DataLayer.ModelClasses;

namespace FoodHunter.FoodHunterWeb.DataLayer.RepositoryInterfaces
{
    interface IReviewRepository
    {
        List<Review> GetAll();
        Review Get(int id);
        int Insert(Review review);
        int Update(Review review);
        int Delete(int id);
    }
}
