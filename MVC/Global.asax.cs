﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ActiveQueryBuilder.Web.Server.Handlers;
using log4net;

namespace MVC_Samples
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            BaseHandler.Log = new Logger();
        }
    }

    public class Logger : ActiveQueryBuilder.Core.ILog
    {
        private static readonly ILog Log = LogManager.GetLogger("Logger");

        public void Trace(string message)
        {
            Log.Info(message);
        }

        public void Warning(string message)
        {
            Log.Warn(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Error(string message, Exception ex)
        {
            Log.Error(message, ex);
        }
    }
}
