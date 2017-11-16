using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Update
{
    public class FoodUpdateViewModel : FoodBaseViewModel
    {
        public int FoodId { get; set; }
    }
}