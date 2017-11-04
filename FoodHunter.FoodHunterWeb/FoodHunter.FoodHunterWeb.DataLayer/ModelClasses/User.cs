using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHunter.FoodHunterWeb.DataLayer.ModelClasses
{
    public enum UserType
    {
        Foodie,
        RestaurantAdmin,
        AppAdmin
    }
    public enum Status
    {
        Active,
        Blocked
    }
    public class User
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression("^([+]?88)?01[15-9]d{8}$", ErrorMessage = "Number format is not valid")]
        public string PhoneNo { get; set; }
        [MinLength(6), ]
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Location { get; set; }
        public DateTime RegisteredOn { get; set; }
        public UserType Type { get; set; }
        public Status CurrentStatus { get; set; }
    }
}
