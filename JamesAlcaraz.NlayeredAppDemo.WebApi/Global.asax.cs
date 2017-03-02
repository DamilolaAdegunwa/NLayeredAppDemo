using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using JamesAlcaraz.NlayeredAppDemo.WebApi.App_Start;

namespace JamesAlcaraz.NlayeredAppDemo.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //var config = new HttpConfiguration();
            //IocContainer.Register(config);
        }
    }
}
