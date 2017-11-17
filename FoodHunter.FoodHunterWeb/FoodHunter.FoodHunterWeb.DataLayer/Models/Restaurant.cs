using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHunter.Web.DataLayer
{
    public class Restaurant
    {
        internal Restaurant()
        {
        }

        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResturantId { get; set; }
        public string RestaurantName { get; set; }
        public string CoverPicture { get; set; }
        public string Location { get; set; }
        public List<Food> FoodMenu { get; set; }
        public List<Review> Reviews { get; set; }
        public Status CurrentStatus { get; set; }
    }
}
