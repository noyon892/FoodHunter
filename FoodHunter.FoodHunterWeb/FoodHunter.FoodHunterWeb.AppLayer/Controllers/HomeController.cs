using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.List;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class HomeController : Controller
    {
        IFoodRepository _foodRepository;
        IRestaurantRepository _restaurantRepository;
        private IReviewRepository _reviewRepository;

        public HomeController()
        {
            _foodRepository = Factory.GetFoodRepository();
            _restaurantRepository = Factory.GetRestaurantRepository();
            _reviewRepository = Factory.GetReviewRepository();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewsList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TopRestaurantList()
        {
            int rating=0;
            //Create Map
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Restaurant, TopRestaurantListViewModel>());
            var mapper = config.CreateMapper();
            //Copy values
            List<TopRestaurantListViewModel> viewModelsList = new List<TopRestaurantListViewModel>();

            foreach (Restaurant restaurant in _restaurantRepository.GetAll())
            {
                List<Review> reviews = _reviewRepository.GetAll()
                    .Where(r => r.RestaurantId == restaurant.RestaurantId).ToList();
                foreach (Review review in reviews)
                {
                    rating += review.Rating;
                }
                TopRestaurantListViewModel topRestaurantListViewModel = mapper.Map<TopRestaurantListViewModel>(restaurant);
                topRestaurantListViewModel.Rating = rating / reviews.Count;
                viewModelsList.Add(topRestaurantListViewModel);
            }
            return View(viewModelsList);
        }

        [HttpGet]
        public ActionResult FoodList()
        {
            //Create Map
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Food, FoodListViewModel>());
            var mapper = config.CreateMapper();
            //Copy values
            List<FoodListViewModel> viewModelsList = new List<FoodListViewModel>();

            foreach (Food food in _foodRepository.GetAll())
            {
                FoodListViewModel foodListViewModel = mapper.Map<FoodListViewModel>(food);
                viewModelsList.Add(foodListViewModel);
            }
            return View(viewModelsList);
        }

        [HttpGet]
        public ActionResult CheckInList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewArrivalList()
        {
            return View();
        }

    }
}