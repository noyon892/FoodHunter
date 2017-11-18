using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.FoodHunterWeb.AppLayer.ViewModels.List
{
    public class TopRestaurantListViewModel
    {
        public int ReataurantID { get; set; }
        public string RestaurantName { get; set; }
        public string Location { get; set; }
        public int Rating { get; set; }
    }
}