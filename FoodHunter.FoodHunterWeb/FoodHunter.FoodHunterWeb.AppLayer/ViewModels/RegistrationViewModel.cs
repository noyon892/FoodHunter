using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.Web.AppLayer
{
    public class RegistrationViewModel
    {
        [Required]
        public string UserName { get; set; }
        [MinLength(6, ErrorMessage = "Password length must be greater than 6 charecter"), DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public UserType Type { get; set; }

        public SelectList TypeList => new SelectList(
            new List<string>
            {
                UserType.Foodie.ToString(),
                UserType.RestaurantAdmin.ToString()
            }
        );
    }
}