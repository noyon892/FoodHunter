using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHunter.FoodHunterWeb.AppLayer.ViewModels.List
{
    public class FoodListViewModel
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
        public string FoodPicture { get; set; }
        public double Rating { get; set; }
    }
}