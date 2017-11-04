using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHunter.FoodHunterWeb.DataLayer.ModelClasses
{
    public class Food
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
        public byte[] FoodPicture { get; set; }
        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }      //Restaurant that hosts the food
        public int DiscoutPercentage { get; set; }      //If any offer is ruuning for discount
        public List<Review> Reviews { get; set; }       //Food review by users
    }
}
