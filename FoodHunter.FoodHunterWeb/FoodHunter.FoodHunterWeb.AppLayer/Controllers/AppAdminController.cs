using AutoMapper;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.List;
using FoodHunter.Web.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class AppAdminController : Controller
    {
        IUserRepository _userRepository;
        IRestaurantRepository _restaurantRepository;

        public AppAdminController()
        {
            _userRepository = Factory.GetUserReposiroty();
            _restaurantRepository = Factory.GetRestaurantRepository();
        }

        // GET: AppAdmin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserList()
        {
            //Create Map
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserListViewModel>());
            var mapper = config.CreateMapper();
            //Copy values
            List<UserListViewModel> viewModelsList = new List<UserListViewModel>();

            foreach (User user in _userRepository.GetAll().Where(u=> u.Type == UserType.Foodie && u.Type == UserType.RestaurantAdmin))
            {
                UserListViewModel userListViewModel = mapper.Map<UserListViewModel>(user);
                viewModelsList.Add(userListViewModel);
            }
            return View(viewModelsList);
        }

        [HttpGet]
        public ActionResult RestaurantList()
        {
            //Create Map
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Restaurant, RestaurantListViewModel>());
            var mapper = config.CreateMapper();
            //Copy values
            List<RestaurantListViewModel> viewModelsList = new List<RestaurantListViewModel>();

            foreach (Restaurant restaurant in _restaurantRepository.GetAll())
            {
                RestaurantListViewModel restaurantListViewModel = mapper.Map<RestaurantListViewModel>(restaurant);
                viewModelsList.Add(restaurantListViewModel);
            }
            return View(viewModelsList);
        }

        [HttpGet]
        public ActionResult ApprovalList()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Restaurant, ApprovalListViewModel>());
            var mapper = config.CreateMapper();
            //Copy values
            List<ApprovalListViewModel> viewModelsList = new List<ApprovalListViewModel>();

            foreach (Restaurant restaurant in _restaurantRepository.GetAll().Where(u=> u.CurrentStatus == Status.Blocked))
            {
                ApprovalListViewModel approvalListViewModel = mapper.Map<ApprovalListViewModel>(restaurant);
                viewModelsList.Add(approvalListViewModel);
            }  
            return View(viewModelsList);
        }
    }
}