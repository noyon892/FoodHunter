using System.ComponentModel.DataAnnotations;

namespace FoodHunter.FoodHunterWeb.AppLayer.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}