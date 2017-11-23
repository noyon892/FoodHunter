using System.Collections.Generic;
using System.Web.DynamicData;
using System.Web.Mvc;
using AutoMapper;
using FoodHunter.Web.AppLayer.ViewModels.List;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.Web.AppLayer.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsContext;

        public NewsController()
        {
            _newsContext = Factory.GetNewsRepository();
        }

        
        // GET: News
        public ActionResult Index()
        {
            //Create Map
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News,NewsListViewModel>());
            var mapper = config.CreateMapper();
            //Copy values
            List<NewsListViewModel> viewModelsList = new List<NewsListViewModel>();

            foreach (News news in _newsContext.GetAll())
            {
                NewsListViewModel newsListViewModel = mapper.Map<NewsListViewModel>(news);
                viewModelsList.Add(newsListViewModel);
            }

            return View(viewModelsList);
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewsListViewModel newsListViewModel)
        {
            //Create Map
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsListViewModel, News>());
            var mapper = config.CreateMapper();

            News news = mapper.Map<News>(newsListViewModel);
            _newsContext.Insert(news);
            
            return RedirectToAction("Index");
        }
    }
}