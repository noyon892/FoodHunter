using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    public class News
    {
        internal News()
        {
        }

        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsId { get; set; }
        public string NewsPicture { get; set; }
        public string Title { get; set; }
        public string NewsBody { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public RestaurantAdmin RestaurantAdmin { get; set; }
    }
}
