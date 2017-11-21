using AutoMapper;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Create;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Update;
using FoodHunter.Web.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodHunter.FoodHunterWeb.AppLayer.Helpers;
using FoodHunter.FoodHunterWeb.AppLayer.Helpers.Annotations;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Details;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.List;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodRepository _foodContext;
        private readonly IReviewRepository _reviewContext;
        private readonly Facade _facade;
        public FoodController()
        {
            _foodContext = Factory.GetFoodRepository();
            _reviewContext = Factory.GetReviewRepository();
            _facade = new Facade();
        }

        [ValidateLogin]
        // GET: Food
        public ActionResult Index(int id)
        {
            return RedirectToAction("Details",id);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult List(int id)
        {
            List<Food> foods = _foodContext.GetAll().Where(r => r.RestaurantId == id).ToList();
            List<FoodListViewModel> foodMenu = new List<FoodListViewModel>();
            
            //create Map
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Food, FoodListViewModel>());
            var mapper = config.CreateMapper();
            //Copy values
            foreach (Food food in foods)
            {
                FoodListViewModel foodViewModel  = mapper.Map<FoodListViewModel>(food);
                foodViewModel.Rating = _facade.GetFoodRating(food.FoodId);
                foodMenu.Add(foodViewModel);
            }
            
            return PartialView(foodMenu);
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
            _foodContext.Insert(foodToInsert);

            return RedirectToAction("Index","Restaurant", new { @id = foodToInsert.RestaurantId });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if(_facade.IsValidFoodAdmin(Convert.ToInt32(Session["UserId"]),id))
            {
                Food foodToUpdate = _foodContext.Get(id);
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Food, FoodEditViewModel>());
                var mapper = config.CreateMapper();
                //Copy values

                FoodEditViewModel foodEdit = mapper.Map<FoodEditViewModel>(foodToUpdate);
                TempData["FoodId"] = id;
                TempData["RestaurantId"] = foodToUpdate.RestaurantId;

                return View(foodEdit);   
            }

            return RedirectToAction("Index", "RestaurantAdmin");
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
            _foodContext.Update(foodToEdit);

            return RedirectToAction("Details", new {@id = foodToEdit.FoodId});
        }

        [HttpGet, ValidateLogin]
        public ActionResult Details(int id)
        {
            Food food = _foodContext.Get(id);
            food.Reviews = _reviewContext.GetAll().Where(r => r.FoodId == id).ToList();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Food, FoodDetailsViewModel>());
            var mapper = config.CreateMapper();

            //Copy values
            FoodDetailsViewModel foodDetails = mapper.Map<FoodDetailsViewModel>(food);

            return View(foodDetails);
        }
    }
}