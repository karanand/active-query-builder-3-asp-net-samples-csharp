﻿using System.Configuration;
using System.IO;
using System.Web.Mvc;
using ActiveQueryBuilder.Core;
using ActiveQueryBuilder.Web.Server;

namespace JavaScript.Controllers
{
    public class WebpackClientRenderingController : Controller
    {
        public ActionResult Index()
        {
			//Please follow the steps described in the Scripts/Webpack/README.md file to run this demo project
            CreateQueryBuilder();
            return View();
        }
        
        /// <summary>
        /// Creates and initializes new instance of the QueryBuilder object if it doesn't exist. 
        /// </summary>
        private void CreateQueryBuilder()
        {
            // Get an instance of the QueryBuilder object
            var qb = QueryBuilderStore.Get("Webpack");

            if (qb != null)
                return;

            // Create an instance of the QueryBuilder object
            var queryBuilder = QueryBuilderStore.Factory.MsSql("Webpack");
            
            // Denies metadata loading requests from the metadata provider
            queryBuilder.MetadataLoadingOptions.OfflineMode = true;

            // Load MetaData from XML document. File name is stored in the "Web.config" file in [/configuration/appSettings/NorthwindXmlMetaData] key
            var path = ConfigurationManager.AppSettings["NorthwindXmlMetaData"];
            var xml = Path.Combine(Server.MapPath("~"), path);

            queryBuilder.MetadataContainer.ImportFromXML(xml);

            //Set default query
            queryBuilder.SQL = GetDefaultSql();
        }

        private string GetDefaultSql()
        {
            return @"Select o.OrderID,
                    c.CustomerID,
                    s.ShipperID,
                    o.ShipCity
                From Orders o
                    Inner Join Customers c On o.CustomerID = c.CustomerID
                    Inner Join Shippers s On s.ShipperID = o.OrderID
                Where o.ShipCity = 'A'";
        }
    }
}