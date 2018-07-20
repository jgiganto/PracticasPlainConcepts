using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Security;
using System.Security.Principal;

namespace Practicas
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void Application_PostAuthenticateRequest
                (object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["cookiecliente"];
            if (cookie != null)
            {
                String datoscookie = cookie.Value;
                FormsAuthenticationTicket ticket =
                    FormsAuthentication.Decrypt(datoscookie);
                String name = ticket.Name;
                String grupo = ticket.UserData;
                GenericIdentity identidad =
                    new GenericIdentity(name);
                GenericPrincipal usuario =
                    new GenericPrincipal(identidad, new string[] { grupo });
                HttpContext.Current.User = usuario;

            }



        }
    }
}
