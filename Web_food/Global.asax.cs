using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
<<<<<<< HEAD
using Web_food.filter;
=======
>>>>>>> 69df8b6a0eee270c1edd2673ee8f528ccee9a202

namespace Web_food
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
<<<<<<< HEAD
            // GlobalFilters.Filters.Add(new AccountFilter());
=======
>>>>>>> 69df8b6a0eee270c1edd2673ee8f528ccee9a202
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}