using FoodHunter.Web.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHunter.FoodHunterWeb.AppLayer.ViewModels.List
{
    public class ApprovalListViewModel
    {
        public string RestaurantName { get; set; }
        public Status CurrentStatus { get; set; }
        
    }
}