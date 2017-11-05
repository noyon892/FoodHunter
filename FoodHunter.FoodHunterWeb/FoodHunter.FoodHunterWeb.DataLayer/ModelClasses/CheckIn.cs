using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHunter.FoodHunterWeb.DataLayer.ModelClasses
{
    public class CheckIn
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CheckInId { get; set; }
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }
        [ForeignKey("UserId")]
        public Foodie Foodie { get; set; }
    }
}
