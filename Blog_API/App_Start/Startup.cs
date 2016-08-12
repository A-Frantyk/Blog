using Blog_API.Authentification_Authorization.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Ninject.Web.WebApi;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

[assembly: OwinStartup(typeof(Blog_API.App_Start.Startup))]

namespace Blog_API.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);

            HttpConfiguration config = new HttpConfiguration();
            NinjectWebCommon.RegisterNinject(config);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            config.MapHttpAttributeRoutes();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
            
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}