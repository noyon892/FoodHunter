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
        private readonly IUserReposiroty _repository;

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
        public ActionResult Index(RegistrationViewModel registrationViewModel)
        {
            //create mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RegistrationViewModel, User>());
            var mapper = config.CreateMapper();

            if (ModelState.IsValid)
            {
                //copy value
                User user = mapper.Map<User>(registrationViewModel);
                user.RegisteredOn = DateTime.Now;
                user.CurrentStatus = Status.Active;
                _repository.Insert(user);

                return RedirectToAction("Index", "Login");
            }

            ModelState.AddModelError("", "Fill all the fields carefully");
            return View();
        }
    }
}