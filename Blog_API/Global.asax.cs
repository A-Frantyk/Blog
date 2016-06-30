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
            GlobalConfiguration.Configure(WebApiConfig.Register);
            NinjectWebCommon.RegisterNinject(GlobalConfiguration.Configuration);
        }
    }
}
