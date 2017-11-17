using FoodHunter.Web.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Base
{
    public class AppAdminBaseViewModel
    {
        public User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string ProfilePicture { get; set; }
        public string Address { get; set; }
    }
}