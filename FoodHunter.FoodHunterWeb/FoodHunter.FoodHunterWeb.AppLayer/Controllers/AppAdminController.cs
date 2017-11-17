using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class AppAdminController : Controller
    {
        // GET: AppAdmin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UserList()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RestaurantList()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ApprovalList()
        {
            return View();
        }
    }
}