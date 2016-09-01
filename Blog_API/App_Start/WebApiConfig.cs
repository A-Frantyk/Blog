
using Blog_Services.UnitOfWork;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using System.Web.Routing;

namespace Blog_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {  
            // Web API configuration and services
            

            // Web API routes
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Enable JSON format returns
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();  // send json keys into camelCase style

        }
    }
}
