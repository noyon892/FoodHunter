using System.Collections.Generic;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.Web.DataLayer
{
    public interface INewsRepository
    {
        List<News> GetAll();
        News Get(int id);
        int Insert(News news);
        int Update(News news);
        int Delete(int id);
    }
}