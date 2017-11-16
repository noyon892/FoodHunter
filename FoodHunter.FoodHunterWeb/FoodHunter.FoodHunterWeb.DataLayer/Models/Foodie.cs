using System.Collections.Generic;
using FoodHunter.Web.DataLayer;

namespace FoodHunter.Web.DataLayer
{
    public class Foodie : UserProfile
    {
        public List<CheckIn> CheckIns { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
