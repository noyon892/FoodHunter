using System.Web.Mvc;
using FoodHunter.FoodHunterWeb;
using FoodHunter.FoodHunterWeb.DataLayer;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFoodRepository _repo = Factory.GetFoodRepository();
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("index","News");
        }
    }
}