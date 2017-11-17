using FoodHunter.Web.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Details
{
    public class RestaurantAdminDetailsViewModel : RestaurantAdminBaseViewModel
    {
        public List<Restaurant> Restaurants { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}