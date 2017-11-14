using System.Collections.Generic;
using System.Web.DynamicData;
using System.Web.Mvc;
using FoodHunter.FoodHunterWeb.DataLayer;
using AutoMapper;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository _repository;

        public NewsController()
        {
            _repository = Factory.GetNewsRepository();
        }

        
        // GET: News
        public ActionResult Index()
        {
            //Create Map
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News,NewsGeneralViewModel>());
            var mapper = config.CreateMapper();
            //Copy values
            List<NewsGeneralViewModel> viewModelsList = new List<NewsGeneralViewModel>();

            foreach (News news in _repository.GetAll())
            {
                NewsGeneralViewModel newsGeneralViewModel = mapper.Map<NewsGeneralViewModel>(news);
                viewModelsList.Add(newsGeneralViewModel);
            }

            return View(viewModelsList);
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewsGeneralViewModel newsGeneralViewModel)
        {
            //Create Map
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsGeneralViewModel, News>());
            var mapper = config.CreateMapper();

            News news = mapper.Map<News>(newsGeneralViewModel);
            _repository.Insert(news);
            
            return RedirectToAction("Index");
        }
    }
}