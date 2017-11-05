using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHunter.FoodHunterWeb.DataLayer.ModelClasses
{
    public class Review
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }
        public string Comment { get; set; }
        [Range(1,10)]
        public byte Rating { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Foodie Reviewer { get; set; }
    }
}
