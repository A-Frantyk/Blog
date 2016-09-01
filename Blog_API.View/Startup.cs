using System;
using Owin;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Blog_API.App_Start;
using System.Web.Http;

namespace Blog_API.View
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);
            app.UseWebApi(config);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}