using FoodHunter.Web.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Details
{
    public class RestaurantAdminDetailsViewModel : ProfileDetailsViewModel
    {
        public List<Restaurant> Restaurants { get; set; }

    }
}