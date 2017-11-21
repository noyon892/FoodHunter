using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodHunter.FoodHunterWeb.AppLayer.Helpers.Annotations
{
    public class ValidateLogin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.Session["UserID"];
            if (user == null)
                if (filterContext.HttpContext.Request.Url != null)
                    filterContext.Result = new RedirectResult(
                        $"/Login/Index?targetUrl={filterContext.HttpContext.Request.Url.AbsolutePath}");
        }
    }
}