using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using AutoMapper;
using LVS.Dtos;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using LVS.Api.App_Start;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace LVS.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {


     


        protected void Application_Start()
        {


            AreaRegistration.RegisterAllAreas();
            AutoMapperConfig.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);



            HttpConfiguration config = GlobalConfiguration.Configuration;

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;


        }



        protected void Application_BeginRequest()
        {
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                Response.Flush();
                Response.End();
            }
        }




    }


}
