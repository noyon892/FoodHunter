using FoodHunter.Web.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHunter.FoodHunterWeb.AppLayer.ViewModels.List
{
    public class UserListViewModel
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public UserType Type { get; set; }
        public UserStatus Status { get; set; }
    }
}