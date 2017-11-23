using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.DynamicData;
using System.Web.Mvc;
using AutoMapper;
using FoodHunter.FoodHunterWeb.AppLayer.Helpers.Annotations;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Details;
using FoodHunter.Web.AppLayer.ViewModels.Create;
using FoodHunter.Web.AppLayer.ViewModels.List;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.Web.AppLayer.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsContext;
        private readonly IRestaurantRepository _restaurantRepository;

        public NewsController()
        {
            _newsContext = Factory.GetNewsRepository();
            _restaurantRepository = Factory.GetRestaurantRepository();
        }

        
        // GET: News
        public ActionResult Index()
        {
            //Create Map
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News,NewsListViewModel>());
            var mapper = config.CreateMapper();
            //Copy values
            List<NewsListViewModel> viewModelsList = new List<NewsListViewModel>();

            List<Restaurant> restaurants = _restaurantRepository.GetAll()
                .Where(u => u.UserId == Convert.ToInt32(Session["UserId"])).ToList();

            foreach (Restaurant restaurant in restaurants)
            {
                foreach (News news in _newsContext.GetAll().Where(r=>r.RestaurantId == restaurant.RestaurantId))
                {
                    NewsListViewModel newsListViewModel = mapper.Map<NewsListViewModel>(news);
                    newsListViewModel.RestaurantName = _restaurantRepository.Get(news.RestaurantId).RestaurantName;
                    viewModelsList.Add(newsListViewModel);
                }
            }
            

            return View(viewModelsList);
        }



        [HttpGet]
        [ValidateLogin]
        public ActionResult Create()
        {
            List<SelectListItem> restaurantList = new List<SelectListItem>();

            foreach (Restaurant restaurant in _restaurantRepository.GetAll()
                .Where(v => v.UserId == Convert.ToInt32(Session["UserId"])))
            {
                SelectListItem option = new SelectListItem
                {
                    Text = restaurant.RestaurantName,
                    Value = restaurant.RestaurantId.ToString()
                };

                restaurantList.Add(option);
            }
            ViewBag.Restaurants = restaurantList;

            return View();
        }

        [HttpPost]
        public ActionResult Create(NewsCreateViewModel newsCreateViewModel)
        {
            //Create Map
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsCreateViewModel, News>());
            var mapper = config.CreateMapper();

            News news = mapper.Map<News>(newsCreateViewModel);
            news.UserId = Convert.ToInt32(Session["UserId"]);
            _newsContext.Insert(news);
            return RedirectToAction("Index","News");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            News news =_newsContext.Get(id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Food, NewsDetailsViewModel>());
            var mapper = config.CreateMapper();

            //Copy values
            NewsDetailsViewModel newsDetails = mapper.Map<NewsDetailsViewModel>(news);

            return View(newsDetails);
        }
    }
}