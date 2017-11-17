using AutoMapper;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Details;
using FoodHunter.Web.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class RestaurantAdminController : Controller
    {
        private readonly IUserProfileRepository _repository;
        private UserProfile _profile;


        public RestaurantAdminController()
        {
            _repository = Factory.GetUserProfileRepository();
        }
        // GET: UserProfile
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                _profile = _repository.Get(Convert.ToInt32(Session["UserId"]));


                //Create Map
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserProfile, RestaurantAdminDetailsViewModel>());
                var mapper = config.CreateMapper();

                //Copy values
                RestaurantAdminDetailsViewModel restauantDetailsViewModel = mapper.Map<RestaurantAdminDetailsViewModel>(_profile);
                if (_profile != null)
                    restauantDetailsViewModel.Email = Session["Email"].ToString();

                return View(restauantDetailsViewModel);
            }

            return RedirectToAction("Index", "Login");
        }


        [HttpGet]
        public ActionResult Edit()
        {
            if (Session["UserId"] != null)
            {
                _profile = _repository.Get(Convert.ToInt32(Session["UserId"]));

                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserProfile, ProfileEditViewModel>());
                var mapper = config.CreateMapper();
                //Copy values

                ProfileEditViewModel profileEditViewModel = mapper.Map<ProfileEditViewModel>(_profile);

                return View(profileEditViewModel);
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Edit(ProfileEditViewModel input)
        {
            if (Session["UserId"] != null)
            {
                _profile = _repository.Get(Convert.ToInt32(Session["UserId"]));

                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProfileEditViewModel, UserProfile>());
                var mapper = config.CreateMapper();
                //Copy values

                UserProfile userProfile = mapper.Map<UserProfile>(input);
                userProfile.UserId = Convert.ToInt32(Session["UserId"]);

                try
                {
                    _repository.Update(userProfile);
                }
                catch (Exception e)
                {
                    _repository.Insert(userProfile);
                    _profile = _repository.Get(Convert.ToInt32(Session["UserId"]));

                    Console.WriteLine(e);
                }

                return RedirectToAction("Index", "Profile");
            }

            return RedirectToAction("Index", "Login");
        }
    }
}