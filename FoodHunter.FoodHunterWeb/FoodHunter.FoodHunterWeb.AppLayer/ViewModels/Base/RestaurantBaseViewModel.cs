using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Base
{
    public class RestaurantBaseViewModel
    {
        public string RestaurantName { get; set; }
        public string CoverPicture { get; set; }
        public string Location { get; set; }
        public List<Food> FoodMenu { get; set; }
        public List<Review> Reviews { get; set; }
    }
}