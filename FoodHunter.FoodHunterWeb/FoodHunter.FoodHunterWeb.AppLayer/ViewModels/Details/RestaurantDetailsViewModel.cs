using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Base;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Details
{
    public class RestaurantDetailsViewModel
    {
        public RestaurantBaseViewModel RestaurantBase { get; set; }
        public RestaurantAdminBaseViewModel RestaurantAdminBase { get; set; }
    }
}