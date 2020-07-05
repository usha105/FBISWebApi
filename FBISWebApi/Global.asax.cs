using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebAPIAuthorizationSample;

namespace FBISWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new ApplicationAuthenticationHandler());
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}
