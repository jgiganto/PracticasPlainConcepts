using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practicas.Controllers
{
    public class ZonasController : Controller
    {
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
        [HttpGet]
        public ActionResult ZonaUser()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ZonaClient()
        {
            return View();
        }
    }
}