using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.Web.AppLayer.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUserRepository _repository;

        public RegistrationController()
        {
            _repository = Factory.GetUserReposiroty();
        }


        // GET: Registration
        public ActionResult Index()
        {
            return View(new RegistrationViewModel());
        }

        [HttpPost]
        public ActionResult Index(RegistrationViewModel input)
        {
            //create mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RegistrationViewModel, User>());
            var mapper = config.CreateMapper();

            if (ModelState.IsValid)
            {
                if (!_repository.GetAll().Exists(u => u.UserName == input.UserName))
                {
                    //copy value
                    User user = mapper.Map<User>(input);
                    user.RegisteredOn = DateTime.Now;
                    user.CurrentStatus = Status.Active;
                    _repository.Insert(user);

                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "User already exist with this userName");
                }
            }
            else
            {
                ModelState.AddModelError("", "Fill all the fields carefully");
            }
            
            return View();
        }
    }
}