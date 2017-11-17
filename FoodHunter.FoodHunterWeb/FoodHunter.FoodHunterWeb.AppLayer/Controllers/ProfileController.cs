using System;
using System.Web.Mvc;
using AutoMapper;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Details;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Edit;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.FoodHunterWeb.AppLayer.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IFoodieRepository _repository;
        private Foodie _profile;


        public ProfileController()
        {
            _repository = Factory.GetFoodieRepository();
        }



        // GET: UserProfile
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                _profile = _repository.Get(Convert.ToInt32(Session["UserId"]));


                //Create Map
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Foodie, ProfileDetailsViewModel>());
                var mapper = config.CreateMapper();
                
                //Copy values
                ProfileDetailsViewModel profileDetails = mapper.Map<ProfileDetailsViewModel>(_profile);
                if (_profile != null)
                {
                    profileDetails.Email = Session["Email"].ToString();
                    profileDetails.CheckIns = _profile.CheckIns;
                }

                return View(profileDetails);  
            }

            return RedirectToAction("Index", "Login");
        }
        

        [HttpGet]
        public ActionResult Edit()
        {
            if (Session["UserId"] != null)
            {
                _profile = _repository.Get(Convert.ToInt32(Session["UserId"]));

                var config = new MapperConfiguration(cfg => cfg.CreateMap<Foodie, ProfileEditViewModel>());
                var mapper = config.CreateMapper();
                //Copy values

                ProfileEditViewModel profileEditViewModel = mapper.Map<ProfileEditViewModel>(_profile);

                return View(profileEditViewModel);
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Edit(ProfileEditViewModel input)
        {
            if (Session["UserId"] != null)
            {
                _profile = _repository.Get(Convert.ToInt32(Session["UserId"]));

                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProfileEditViewModel, Foodie>());
                var mapper = config.CreateMapper();
                //Copy values

                Foodie userProfile = mapper.Map<Foodie>(input);
                userProfile.UserId = Convert.ToInt32(Session["UserId"]);

                try
                {
                    _repository.Update(userProfile);
                }
                catch (Exception e)
                {
                    _repository.Insert(userProfile);
                    _profile = _repository.Get(Convert.ToInt32(Session["UserId"]));

                    Console.WriteLine(e);
                }

                return RedirectToAction("Index", "Profile");
            }

            return RedirectToAction("Index", "Login");
        }
    }
}