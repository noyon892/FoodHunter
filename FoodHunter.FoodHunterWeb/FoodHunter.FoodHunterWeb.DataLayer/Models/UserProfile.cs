using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHunter.Web.DataLayer
{
    public class UserProfile
    {
        internal UserProfile()
        {
        }

        [Key]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[RegularExpression("^([+]?88)?01[15-9]d{8}$", ErrorMessage = "Number format is not valid")]
        public string PhoneNo { get; set; }
        public string ProfilePicture { get; set; }
        public string Address { get; set; }
    }
}
