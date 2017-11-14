using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    public class Profile
    {
        internal Profile()
        {
        }

        [Key]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression("^([+]?88)?01[15-9]d{8}$", ErrorMessage = "Number format is not valid")]
        public string PhoneNo { get; set; }
        [MinLength(6)]
        public string FullName { get; set; }
        public string ProfilePicture { get; set; }
        public string Address { get; set; }
    }
}
