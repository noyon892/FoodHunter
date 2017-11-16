using System.Web.Mvc;
using FoodHunter.Web;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.Web.AppLayer.Controllers
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