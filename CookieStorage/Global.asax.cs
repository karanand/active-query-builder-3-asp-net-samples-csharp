﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ActiveQueryBuilder.Web.Server;
using CookieStorage.Providers;

namespace CookieStorage
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Redefine the QueryBuilderStore.Provider object to be an instance of the CookieQueryBuilderProvider class
            QueryBuilderStore.Provider = new CookieQueryBuilderProvider();
        }
    }
}
