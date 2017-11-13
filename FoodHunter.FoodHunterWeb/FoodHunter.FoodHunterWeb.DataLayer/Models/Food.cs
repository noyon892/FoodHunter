using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    public class Food
    {
        internal Food()
        {
        }

        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
        public string FoodPicture { get; set; }
        public int DiscoutPercentage { get; set; }      //If any offer is ruuning for discount
        public List<Review> Reviews { get; set; }       //Food review by users
        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }      //Restaurant that hosts the food
    }
}
