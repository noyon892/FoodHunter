using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    public class User
    {
        internal User()
        {
            RegisteredOn = DateTime.Now;
            CurrentUserStatus = UserStatus.Active;
        }

        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? RegisteredOn { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime LastActivity { get; set; }
        public UserStatus CurrentUserStatus { get; set; }
        public UserType Type { get; set; }
    }
}