using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    public class Login
    {
        internal Login()
        {
        }

        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime LastActivity { get; set; }
        public UserStatus CurrentUserStatus { get; set; }
    }
}