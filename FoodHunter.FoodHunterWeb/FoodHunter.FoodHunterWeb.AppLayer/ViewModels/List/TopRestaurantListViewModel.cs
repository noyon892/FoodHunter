using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.FoodHunterWeb.AppLayer.ViewModels.List
{
    public class TopRestaurantListViewModel
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string Location { get; set; }
        public double Rating { get; set; }
    }
}