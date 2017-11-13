using System.Collections.Generic;
using FoodHunter.FoodHunterWeb.DataLayer;

namespace FoodHunter.FoodHunterWeb.DataLayer
{
    public class Foodie : User
    {
        internal Foodie()
        {
            Type = UserType.Foodie;
        }

        public List<CheckIn> CheckIns { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
