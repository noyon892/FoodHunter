using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Base;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Details;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantRepository _restaurantContext;
        private readonly IUserProfileRepository _userContext;
        private readonly IFoodRepository _foodRepository;
        private readonly IReviewRepository _reviewRepository;

        public RestaurantController()
        {
            _restaurantContext = Factory.GetRestaurantRepository();
            _userContext = Factory.GetUserProfileRepository();
            _foodRepository = Factory.GetFoodRepository();
            _reviewRepository = Factory.GetReviewRepository();
        }



        // GET: Restaurant
        public ActionResult Index(int id)
        {
            Restaurant restaurant = _restaurantContext.Get(id);
            restaurant.FoodMenu = (List<Food>)_foodRepository.GetAll().Where(f => f.RestaurantId == restaurant.ResturantId);
            restaurant.Reviews = (List<Review>)_reviewRepository.GetAll().Where(r => r.RestaurantId == restaurant.ResturantId);
            UserProfile restaurantAdmin = _userContext.Get(restaurant.ResturantId);

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
            };
            #endregion


            return View(restaurantDetails);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
    }
}