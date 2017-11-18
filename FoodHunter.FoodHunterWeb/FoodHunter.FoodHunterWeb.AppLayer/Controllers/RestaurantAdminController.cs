using AutoMapper;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Details;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Edit;
using FoodHunter.Web.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodHunter.Web.AppLayer.Controllers
{
    public class RestaurantAdminController : Controller
    {
        private IRestaurantAdminRepository _repository;
        private IRestaurantRepository _restaurantRepository;
        private RestaurantAdmin _profile;


        public RestaurantAdminController()
        {
            InitilizeRepository();
        }

        private void InitilizeRepository()
        {
            _repository = Factory.GetRestaurantAdminRepository();
            _restaurantRepository = Factory.GetRestaurantRepository();
        }

        // GET: UserProfile
        public ActionResult Index()
        {
            InitilizeRepository();
            if (Session["UserId"] != null)
            {
                _profile = _repository.Get(Convert.ToInt32(Session["UserId"]));


                //Create Map
                var config = new MapperConfiguration(cfg => cfg.CreateMap<RestaurantAdmin, RestaurantAdminDetailsViewModel>());
                var mapper = config.CreateMapper();

                //Copy values
                RestaurantAdminDetailsViewModel restaurantAdminDetails = mapper.Map<RestaurantAdminDetailsViewModel>(_profile);
                if (_profile != null)
                {
                    restaurantAdminDetails.Email = Session["Email"].ToString();

                    restaurantAdminDetails.Restaurants = _restaurantRepository.GetAll()
                        .Where(u => u.UserId == Convert.ToInt32(Session["UserId"])).ToList();
                }
                return View(restaurantAdminDetails);
            }

            return RedirectToAction("Index", "Login");
        }


        [HttpGet]
        public ActionResult Edit()
        {
            if (Session["UserId"] != null)
            {
                _profile = _repository.Get(Convert.ToInt32(Session["UserId"]));

                var config = new MapperConfiguration(cfg => cfg.CreateMap<RestaurantAdmin, RestaurantAdminEditViewModel>());
                var mapper = config.CreateMapper();
                //Copy values

                RestaurantAdminEditViewModel restaurantAdminEditViewModel = mapper.Map<RestaurantAdminEditViewModel>(_profile);

                return View(restaurantAdminEditViewModel);
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Edit(RestaurantAdminEditViewModel input)
        {
            if (Session["UserId"] != null)
            {
                _profile = _repository.Get(Convert.ToInt32(Session["UserId"]));

                var config = new MapperConfiguration(cfg => cfg.CreateMap<RestaurantAdminEditViewModel, RestaurantAdmin>());
                var mapper = config.CreateMapper();
                //Copy values

                RestaurantAdmin userProfile = mapper.Map<RestaurantAdmin>(input);
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

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Login");
        }
    }
}