﻿using System;
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

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantRepository _restaurantContext;
        private readonly IFoodieRepository _foodieContext;
        private readonly IFoodRepository _foodRepository;
        private readonly IReviewRepository _reviewRepository;

        public RestaurantController()
        {
            _restaurantContext = Factory.GetRestaurantRepository();
            _foodieContext = Factory.GetFoodieRepository();
            _foodRepository = Factory.GetFoodRepository();
            _reviewRepository = Factory.GetReviewRepository();
        }



        // GET: Restaurant
        public ActionResult Index(int id)
        {
            Restaurant restaurant = _restaurantContext.Get(id);
            restaurant.FoodMenu = (List<Food>)_foodRepository.GetAll().Where(f => f.RestaurantId == restaurant.ResturantId);
            restaurant.Reviews = (List<Review>)_reviewRepository.GetAll().Where(r => r.RestaurantId == restaurant.ResturantId);
            UserProfile restaurantAdmin = _foodieContext.Get(restaurant.ResturantId);

            #region Setting Values to View Model
            //Copy restaurant values to restaurantbase
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Restaurant, RestaurantBaseViewModel>());
            var mapper = config.CreateMapper();

            //Copy values
            RestaurantBaseViewModel restaurantBase = mapper.Map<RestaurantBaseViewModel>(restaurant);


            //Copy restaurant admin values to restaurantAdminBase
            config = new MapperConfiguration(cfg => cfg.CreateMap<RestaurantAdmin, ViewModels.Base.RestaurantAdminBaseViewModel>());
            mapper = config.CreateMapper();

            //Copy values
            ViewModels.Base.RestaurantAdminBaseViewModel restaurantAdminBase = mapper.Map<ViewModels.Base.RestaurantAdminBaseViewModel>(restaurantAdmin);

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

            return RedirectToAction("Index");
           
        }
    }
}