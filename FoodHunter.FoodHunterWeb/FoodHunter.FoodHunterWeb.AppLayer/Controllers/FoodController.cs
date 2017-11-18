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
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(FoodCreateViewModel foodCreate)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FoodCreateViewModel, Food>());
            var mapper = config.CreateMapper();

            Food food = mapper.Map<Food>(foodCreate);
            _repository.Insert(food);
            return RedirectToAction("Index","Restaurant",1);
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(FoodUpdateViewModel input)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FoodUpdateViewModel, Food>());
            var mapper = config.CreateMapper();
            //Copy values

            Food foodToUpdate = mapper.Map<Food>(input);
            _repository.Update(foodToUpdate);

            return RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Food food = _repository.Get(id);
            food.Reviews = (List<Review>)_reviewRepository.GetAll().Where(r => r.FoodId == id);

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
            reviewToCreate.UserId = Convert.ToInt32(Session["UserId"]);
            reviewToCreate.FoodId = id;

            _reviewRepository.Insert(reviewToCreate);

            return View();
        }
    }
}