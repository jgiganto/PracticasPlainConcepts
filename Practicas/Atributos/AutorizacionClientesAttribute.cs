using Practicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Practicas.Atributos
{
    public class AutorizacionClientesAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                //UserPrincipal usuario = HttpContext.Current.User as UserPrincipal;
                GenericPrincipal usuario = HttpContext.Current.User as GenericPrincipal;
                
                if (usuario.IsInRole("Admin") == false
                    && usuario.IsInRole("User") == false
                   && usuario.IsInRole("Client") == false
                    )
                {
                    RouteValueDictionary rutaacceso =
                       new RouteValueDictionary(new
                       {
                           controller = "Zonas"
                           ,
                           action = "ErrorAcceso"
                       });
                    RedirectToRouteResult direccionacceso =
                        new RedirectToRouteResult(rutaacceso);
                    filterContext.Result = direccionacceso;
                }
                else
                {
                    if (usuario.IsInRole("Admin") == true)
                    {
                        RouteValueDictionary ruta =
                             new RouteValueDictionary(new
                             {
                                 controller = "Zonas"
                             ,
                                 action = "ZonaAdmin"
                             });
                        RedirectToRouteResult direccionlogin =
                     new RedirectToRouteResult(ruta);
                     filterContext.Result = direccionlogin;
                    }else
                    if (usuario.IsInRole("User") == true)
                    {
                        RouteValueDictionary ruta =
                             new RouteValueDictionary(new
                             {
                                 controller = "Zonas"
                             ,
                                 action = "ZonaUser"
                             });
                        RedirectToRouteResult direccionlogin =
                     new RedirectToRouteResult(ruta);
                        filterContext.Result = direccionlogin;
                    }else
                    if (usuario.IsInRole("Client") == true)
                    {
                        RouteValueDictionary ruta =
                             new RouteValueDictionary(new
                             {
                                 controller = "Zonas"
                             ,
                                 action = "ZonaClient"
                             });
                        RedirectToRouteResult direccionlogin =
                     new RedirectToRouteResult(ruta);
                        filterContext.Result = direccionlogin;
                    }
                }
            }

        }
    }
}