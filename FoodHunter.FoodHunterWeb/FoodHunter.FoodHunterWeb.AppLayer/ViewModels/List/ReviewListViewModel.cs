using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodHunter.FoodHunterWeb.AppLayer.ViewModels.List
{
    public class ReviewListViewModel
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public byte Rating { get; set; }
        public string FoodPicture { get; set; }
        public string Comment { get; set; }

    }
}