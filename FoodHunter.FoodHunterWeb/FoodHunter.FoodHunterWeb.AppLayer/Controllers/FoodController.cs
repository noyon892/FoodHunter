using AutoMapper;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Create;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Update;
using FoodHunter.Web.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Details;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class FoodController : Controller
    {
        IFoodRepository _repository;
        private IReviewRepository _reviewRepository;
        public FoodController()
        {
            _repository = Factory.GetFoodRepository();
            _reviewRepository = Factory.GetReviewRepository();
        }

        // GET: Food
        public ActionResult Index(int id)
        {
            return RedirectToAction("Details",id);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            TempData["RestaurantId"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult Create(FoodCreateViewModel input)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FoodCreateViewModel, Food>());
            var mapper = config.CreateMapper();

            Food foodToInsert = mapper.Map<Food>(input);
            foodToInsert.RestaurantId = Convert.ToInt32(TempData["RestaurantId"]);
            _repository.Insert(foodToInsert);

            return RedirectToAction("Index","Restaurant", new { @id = foodToInsert.RestaurantId });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Food foodToUpdate = _repository.Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Food, FoodEditViewModel>());
            var mapper = config.CreateMapper();
            //Copy values

            FoodEditViewModel foodEdit = mapper.Map<FoodEditViewModel>(foodToUpdate);
            TempData["FoodId"] = id;
            TempData["RestaurantId"] = foodToUpdate.RestaurantId;

            return View(foodEdit);
        }

        [HttpPost]
        public ActionResult Edit(FoodEditViewModel input)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FoodEditViewModel, Food>());
            var mapper = config.CreateMapper();
            //Copy values

            Food foodToEdit = mapper.Map<Food>(input);
            foodToEdit.FoodId = Convert.ToInt32(TempData["FoodId"]);
            foodToEdit.RestaurantId = Convert.ToInt32(TempData["RestaurantId"]);
            _repository.Update(foodToEdit);

            return RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Food food = _repository.Get(id);
            food.Reviews = _reviewRepository.GetAll().Where(r => r.FoodId == id).ToList();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Food, FoodDetailsViewModel>());
            var mapper = config.CreateMapper();

            //Copy values
            FoodDetailsViewModel foodDetails = mapper.Map<FoodDetailsViewModel>(food);

            return View(foodDetails);
        }

        [HttpPost]
        public ActionResult Details(int id, ReviewCreateViewModel input)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReviewCreateViewModel, Review>());
            var mapper = config.CreateMapper();

            //Copy values
            Review reviewToCreate = mapper.Map<Review>(input);

            _reviewRepository.Insert(reviewToCreate);

            return View();
        }
    }
}