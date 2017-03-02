using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using JamesAlcaraz.NlayeredAppDemo.Application.InfrastructureServices.Authentication;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework;
using JamesAlcaraz.NlayeredAppDemo.WebApi.Repository;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;


namespace JamesAlcaraz.NlayeredAppDemo.WebApi.App_Start
{
    public class IocContainer
    {
        public static ContainerBuilder GetBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //ASP.Net Identity Services
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.Register(c => new UserStore<ApplicationUser>(c.Resolve<ApplicationDbContext>())).AsImplementedInterfaces().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            builder.Register(c => new IdentityFactoryOptions<ApplicationUserManager>
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("NLayeredAppDemo​")
            });

            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerRequest();

            //Register AuthorizationServerProvider in the root scope for Owin Startup use
            builder.RegisterType<AuthorizationServerProvider>().As<IOAuthAuthorizationServerProvider>().SingleInstance();

            return builder;
        }
    }
}