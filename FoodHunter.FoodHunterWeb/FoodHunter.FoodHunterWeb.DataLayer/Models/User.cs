using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.Web.DataLayer
{
    public class User
    {
        internal User(){}

        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(6)]  
        public string Password { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime RegisteredOn { get; set; }
        [Column(TypeName = "datetime2")][NotMapped]
        public DateTime LastActivity { get; set; }
        public Status CurrentStatus { get; set; }
        public UserType Type { get; set; }
    }
}