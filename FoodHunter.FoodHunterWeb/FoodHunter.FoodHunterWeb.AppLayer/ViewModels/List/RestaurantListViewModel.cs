using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.FoodHunterWeb.AppLayer.ViewModels.List
{
    public class RestaurantListViewModel
    {
        public string RestaurantName { get; set; }
        public int RestaurantId { get; set; }
        public Status CurrentStatus { get; set; }
    }
}