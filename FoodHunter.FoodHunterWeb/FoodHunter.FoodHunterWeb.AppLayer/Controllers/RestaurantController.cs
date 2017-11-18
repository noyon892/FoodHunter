using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Base;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Details;
using FoodHunter.Web.DataLayer;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Create;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Edit;
using FoodHunter.FoodHunterWeb.DataLayer;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantRepository _restaurantContext;
        private readonly IFoodieRepository _foodieContext;
        private IRestaurantAdminRepository _restaurantAdminContext;
        private readonly IFoodRepository _foodRepository;
        private readonly IReviewRepository _reviewRepository;

        public RestaurantController()
        {
            _restaurantContext = Factory.GetRestaurantRepository();
            _foodieContext = Factory.GetFoodieRepository();
            _restaurantAdminContext = Factory.GetRestaurantAdminRepository();
            _foodRepository = Factory.GetFoodRepository();
            _reviewRepository = Factory.GetReviewRepository();
        }



        // GET: Restaurant
        public ActionResult Index(int id)
        {
            Restaurant restaurant = _restaurantContext.Get(id);
            restaurant.Reviews = (List<Review>)_reviewRepository.GetAll().Where(r => r.RestaurantId == restaurant.ResturantId).ToList();
            RestaurantAdmin restaurantAdmin = _restaurantAdminContext.Get(restaurant.ResturantId);

            #region Setting Values to View Model
            //Copy restaurant values to restaurantbase
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Restaurant, RestaurantBaseViewModel>());
            var mapper = config.CreateMapper();

            //Copy values
            RestaurantBaseViewModel restaurantBase = mapper.Map<RestaurantBaseViewModel>(restaurant);


            //Copy restaurant admin values to restaurantAdminBase
            config = new MapperConfiguration(cfg => cfg.CreateMap<RestaurantAdmin, RestaurantAdminBaseViewModel>());
            mapper = config.CreateMapper();

            //Copy values
            RestaurantAdminBaseViewModel restaurantAdminBase = mapper.Map<RestaurantAdminBaseViewModel>(restaurantAdmin);

            RestaurantDetailsViewModel restaurantDetails = new RestaurantDetailsViewModel
            {
                RestaurantBase = restaurantBase,
                ProfileDetails = restaurantAdminBase
            };
            #endregion


            return View(restaurantDetails);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(RestaurantEditViewModel input)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RestaurantEditViewModel, Restaurant>());
            var mapper = config.CreateMapper();
            //Copy values

            Restaurant restaurantToUpdate = mapper.Map<Restaurant>(input);
            _restaurantContext.Update(restaurantToUpdate);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantCreateViewModel restaurantCreate)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RestaurantCreateViewModel, Restaurant>());
            var mapper = config.CreateMapper();

            Restaurant restaurant = mapper.Map<Restaurant>(restaurantCreate);
            restaurant.UserId = Convert.ToInt32(Session["UserId"]);
            _restaurantContext.Insert(restaurant);

            return RedirectToAction("Index","RestaurantAdmin");
           
        }
    }
}