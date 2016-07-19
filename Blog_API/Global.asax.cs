using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Mvc;

using Blog_API;
using Blog_API.Dependency_Injection;
using Blog_API.App_Start;

namespace Blog_API
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            // Enable json serializing fields that may contains 'null' value &
            // fields with default value
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Include,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Include
            };

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);


            GlobalConfiguration.Configure(WebApiConfig.Register);
            NinjectWebCommon.RegisterNinject(GlobalConfiguration.Configuration);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
