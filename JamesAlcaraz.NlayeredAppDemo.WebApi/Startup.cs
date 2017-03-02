using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using JamesAlcaraz.NlayeredAppDemo.Application.InfrastructureServices.Authentication;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework;
using JamesAlcaraz.NlayeredAppDemo.WebApi.App_Start;
using JamesAlcaraz.NlayeredAppDemo.WebApi.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(JamesAlcaraz.NlayeredAppDemo.WebApi.Startup))]
namespace JamesAlcaraz.NlayeredAppDemo.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureOAuth(app);
            
            var config = new HttpConfiguration();

            //Setup Web Api Routes, Formatter,, Exception Handlers, etc.
            WebApiConfig.Register(config);

            //Register autofac services
            var builder = IocContainer.GetBuilder();

            //Set dependency builder to be Autofac
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // OWIN WEB API SETUP:

            // Register the Autofac middleware FIRST, then the Autofac Web API middleware,
            // and finally the standard Web API middleware.
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);

            ConfigureOAuth(app);
            app.UseWebApi(config);

        }
        private void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider() //container.Resolve<IOAuthAuthorizationServerProvider>()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}