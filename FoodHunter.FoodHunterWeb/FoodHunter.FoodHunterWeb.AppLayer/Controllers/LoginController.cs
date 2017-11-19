using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IUserRepository _reposiroty;

        public LoginController()
        {
            _reposiroty = Factory.GetUserReposiroty();
        }

        // GET: Login
        public ActionResult Index(string targetUrl)
        {
            ViewBag.ReturnUrl = targetUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel input, string returnUrl)
        {
            var user = _reposiroty.GetAll().SingleOrDefault(u => u.UserName == input.UserName && u.Password == input.Password);
            if (user != null)
            {
                Session["UserId"] = user.UserId;
                Session["UserName"] = user.UserName;
                Session["Email"] = user.Email;
                Session["UserType"] = user.Type;

                if(user.Type == UserType.Foodie)
                {
                    return RedirectToLocal(returnUrl);
                }
                else if (user.Type == UserType.RestaurantAdmin)
                {
                    return RedirectToAction("Index", "RestaurantAdmin");
                }
                else if (user.Type == UserType.AppAdmin)
                {
                    return RedirectToAction("Index", "AppAdmin");
                }
                
                
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