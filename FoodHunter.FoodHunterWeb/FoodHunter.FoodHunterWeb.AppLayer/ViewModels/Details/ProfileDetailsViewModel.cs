using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Base;

namespace FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Details
{
    public class ProfileDetailsViewModel : ProfileBaseViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}