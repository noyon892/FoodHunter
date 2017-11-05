using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodHunter.FoodHunterWeb.DataLayer.RepositoryInterfaces;
using FoodHunter.FoodHunterWeb.DataLayer.Repositories;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class HomeController : Controller
    {
        private IFoodRepository repo = new FoodRepository();
        // GET: Home
        public ActionResult Index()
        {
            return View(this.repo.GetAll());
        }
    }
}