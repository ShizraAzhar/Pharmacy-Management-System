using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DB_Pharmacy.App_Start;

namespace DB_Pharmacy
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            FilterConfig.ReigisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
