using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FoodHunter.FoodHunterWeb.DataLayer;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUserReposiroty _repository;

        public RegistrationController()
        {
            _repository = Factory.UserReposiroty();
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

            //copy value
            User user = mapper.Map<User>(registrationViewModel);
            _repository.Insert(user);
            
            return View(new RegistrationViewModel());
        }
    }
}