using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHunter.FoodHunterWeb.DataLayer.ModelClasses
{
    public class Foodie : User
    {
        public Foodie()
        {
            Type = UserType.Foodie;
        }

        public List<CheckIn> CheckIns { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
