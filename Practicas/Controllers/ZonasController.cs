using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;

namespace Practicas.Controllers
{
    public class ZonasController : Controller
    {
        public void LogOut(){
            ViewBag.res = "Adios " + HttpContext.User.Identity.Name.ToString() + " !!";
            HttpContext.User =
            new GenericPrincipal(new GenericIdentity(""), null);
            System.Web.Security.FormsAuthentication.SignOut();
            HttpCookie cookie =
                Request.Cookies["cookiecliente"];
            cookie.Expires =
                DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);
        }

       
        // GET: Zonas
        [HttpGet]
        public ActionResult ErrorAcceso()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ZonaAdmin()
        {
             
            return View();
        }
        [HttpPost]
        public ActionResult ZonaAdmin(String noUseMe)
        {
           
            this.LogOut();
            return View();
        }

        [HttpGet]
        public ActionResult ZonaUser()
        {
            this.LogOut();
            return View();
        }
        [HttpGet]
        public ActionResult ZonaClient()
        {
            this.LogOut();
            return View();
        }

        public ActionResult LogOutWindow()
        {
            return View();
        }
    }
}