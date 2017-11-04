using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHunter.FoodHunterWeb.DataLayer.ModelClasses
{
    class AppAdmin : User
    {
        public AppAdmin()
        {
            Type = UserType.AppAdmin;
        }
    }
}
