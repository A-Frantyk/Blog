
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

namespace Blog_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Register types using NInject

            //var _kernel = new StandardKernel();


            //var _igenericRepository = _kernel.TryGet(typeof(IGenericRepository<>));
            

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
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
