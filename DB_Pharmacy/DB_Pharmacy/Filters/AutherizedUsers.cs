using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_Pharmacy.Filters
{
    public class AuthorizedUser : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["islogin"] == null)
            {
                filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    {"Area", ""},
                    {"Controller", "Login"},
                    {"Action", "Login"}
                });

            }
            base.OnActionExecuting(filterContext);
        }
    }
}