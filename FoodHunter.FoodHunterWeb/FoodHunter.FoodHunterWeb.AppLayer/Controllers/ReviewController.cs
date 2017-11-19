using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Create;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.List;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private IFoodieRepository _foodieRepository;

        public ReviewController()
        {
            _reviewRepository = Factory.GetReviewRepository();
            _foodieRepository = Factory.GetFoodieRepository();
        }

        // GET: Review
        public ActionResult Index()
        {
            return View();
        }



        //For food
        [HttpGet]
        [ChildActionOnly]
        public ActionResult FoodReviewCreate(int id)
        {
            TempData["FoodId"] = id;
            return PartialView();
        }

        [HttpPost]
        public ActionResult FoodReviewCreate(ReviewCreateViewModel input)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReviewCreateViewModel, Review>());
            var mapper = config.CreateMapper();

            //Copy values
            Review reviewToCreate = mapper.Map<Review>(input);
            reviewToCreate.UserId = Convert.ToInt32(Session["UserId"]);
            reviewToCreate.FoodId = Convert.ToInt32(TempData["FoodId"]);

            _reviewRepository.Insert(reviewToCreate);

            return RedirectToAction("Details", "Food", new {@id = reviewToCreate.FoodId});
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult FoodReviewList(int id)
        {
            List<Review> reviews = _reviewRepository.GetAll().Where(f => f.FoodId == id).ToList();
            var reviewListViewModels = new List<ReviewListViewModel>();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewListViewModel>());
            var mapper = config.CreateMapper();

            foreach (Review review in reviews)
            {
                ReviewListViewModel reviewListViewModel = mapper.Map<ReviewListViewModel>(review);
                reviewListViewModels.Add(reviewListViewModel);
                Foodie foodie = _foodieRepository.Get(reviewListViewModel.UserId);
                reviewListViewModel.UserName = foodie.FirstName + foodie.LastName;
            }

            return PartialView(reviewListViewModels);
        }
    }
}