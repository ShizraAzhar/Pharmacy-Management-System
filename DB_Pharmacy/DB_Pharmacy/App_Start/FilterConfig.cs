using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB_Pharmacy.Filters;

namespace DB_Pharmacy.App_Start
{
    public class FilterConfig
    {
        public static void ReigisterGlobalFilters(GlobalFilterCollection filtters)
        {
            filtters.Add(new ExceptionFilter());

        }
    }
}