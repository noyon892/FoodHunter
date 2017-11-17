using AutoMapper;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Create;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Update;
using FoodHunter.Web.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class FoodController : Controller
    {
        IFoodRepository _repository;
        public FoodController()
        {
            _repository = Factory.GetFoodRepository();
        }

        // GET: Food
        public ActionResult Index()
        {
            return RedirectToAction("Details");
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
            return View();
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
        public ActionResult Details()
        {
            return View();
        }


    }
}