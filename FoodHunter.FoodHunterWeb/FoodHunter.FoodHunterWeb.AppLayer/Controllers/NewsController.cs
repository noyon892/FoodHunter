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
            _repository = Factory.GeNewsRepository();
        }

        
        // GET: News
        public ActionResult Index()
        {
            //Create Map
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News,GeneralNewsViewModel>());
            var mapper = config.CreateMapper();
            //Copy values
            List<GeneralNewsViewModel> viewModelsList = new List<GeneralNewsViewModel>();

            foreach (News news in _repository.GetAll())
            {
                GeneralNewsViewModel generalNewsViewModel = mapper.Map<GeneralNewsViewModel>(news);
                viewModelsList.Add(generalNewsViewModel);
            }

            return View(viewModelsList);
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GeneralNewsViewModel generalNewsViewModel)
        {
            //Create Map
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GeneralNewsViewModel, News>());
            var mapper = config.CreateMapper();

            News news = mapper.Map<News>(generalNewsViewModel);
            _repository.Insert(news);
            
            return RedirectToAction("Index");
        }
    }
}