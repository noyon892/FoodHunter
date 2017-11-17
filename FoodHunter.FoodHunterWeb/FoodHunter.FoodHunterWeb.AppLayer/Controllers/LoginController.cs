using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _reposiroty;

        public LoginController()
        {
            _reposiroty = Factory.GetUserReposiroty();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel input)
        {
            var user = _reposiroty.GetAll().SingleOrDefault(u => u.UserName == input.UserName && u.Password == input.Password);
            if (user != null)
            {
                Session["UserId"] = user.UserId;
                Session["UserName"] = user.UserName;
                Session["Email"] = user.Email;
                Session["UserType"] = user.Type;
                return RedirectToAction("Index", "Profile");
            }

            ModelState.AddModelError("", "UserName or Password is wrong");
            
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}