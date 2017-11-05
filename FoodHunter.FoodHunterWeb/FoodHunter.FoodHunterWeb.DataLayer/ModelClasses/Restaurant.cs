using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHunter.FoodHunterWeb.DataLayer.ModelClasses
{
    public class Restaurant
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResturantId { get; set; }
        public string RestaurantName { get; set; }
        public string Location { get; set; }
        public List<Food> FoodMenu { get; set; }
    }
}
