using Practicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Practicas.Atributos;

namespace Practicas.Controllers
{
    public class UsersController : Controller
    {
        ModeloUsuarios modelo;
        public void CrearModelo()
        {            
            modelo = new ModeloUsuarios();
        }

        
        [AutorizacionClientes]
        public ActionResult Index()
        {
            ViewBag.res = "Usuario correcto";
            ViewBag.color = "green";
            ViewBag.Rol = TempData["ROL"].ToString();

            this.CrearModelo();
            List<NewUserModel> lista = modelo.GetUsuarios();
            

            if (ModelState.IsValid)
            {
                return View(lista);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String camponombre, String campopw)
        {
            //int count = 0;
            this.CrearModelo();
            NewUserModel usuario = new NewUserModel();
            usuario.Nickname = camponombre;
            usuario.Password = campopw;
            IEnumerable<NewUserModel> result =  modelo.VerificarUsuario(usuario);
            var count = result.Count();
            usuario = result.FirstOrDefault();
                        
            if (count == 1 )
            {
                //UserPrincipal usuarioppal = HttpContext.User as UserPrincipal;
                IEnumerable<Practicas.Models.Roles> userRoles = modelo.GetRoleByUserId(usuario.UserId);
                String currentRol="";
                if (userRoles.Any(r => r.Role == "Admin") == true)
                {
                      currentRol = "Admin";
                    TempData["ROL"] = "El usuario es: Admin";
                }
                if (userRoles.Any(r => r.Role == "Client") == true)
                {
                      currentRol = "Client";
                    TempData["ROL"] = "El usuario es: Client";
                }
                if (userRoles.Any(r => r.Role == "User") == true)
                {
                      currentRol = "User";
                    TempData["ROL"] = "El usuario es: User";
                }

                FormsAuthenticationTicket ticket =
                    new FormsAuthenticationTicket(1, usuario.Name.ToString(), DateTime.Now, DateTime.Now.AddSeconds(15), true, currentRol, FormsAuthentication.FormsCookiePath);
                String ticketEncrypted = FormsAuthentication.Encrypt(ticket);
                HttpCookie httpCookie = new HttpCookie("cookiecliente", ticketEncrypted);
                Response.Cookies.Add(httpCookie);

               
            }
            else
            {
                ModelState.AddModelError("Error", "El usuario no se corresponde");
            }
            List<NewUserModel> lista = modelo.GetUsuarios();
            if (ModelState.IsValid)
            {
                return View(lista);
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateNewUser()
        {
            var model = new NewUsersModel();
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewUser(NewUserModel model,String rol)
        {
            if (ModelState.IsValid)
            {
                this.CrearModelo();
                modelo.InsertarUsuario(model,rol);
                TempData["ROL"] = "El usuario ha sido dado de alta";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}