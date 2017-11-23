using System.Web;
using FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Base;

namespace FoodHunter.FoodHunterWeb.AppLayer.ViewModels.Edit
{
    public class FoodieEditViewModel : FoodieBaseViewModel
    {
        public HttpPostedFileBase PostedPicture { get; set; }
        public string ProfilePicture { get; set; }
    }
}