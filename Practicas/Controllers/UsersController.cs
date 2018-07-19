using Practicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Practicas.Controllers
{
    public class UsersController : Controller
    {
        ModeloUsuarios modelo;
        public void CrearModelo()
        {            
            modelo = new ModeloUsuarios();
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.res = "Usuario correcto";
            ViewBag.color = "green";
            ViewBag.Rol = TempData["ROL"].ToString();

            this.CrearModelo();
            List<NewUserModel> lista = modelo.GetUsuarios();
            var Usuario=
            if()
            if (ModelState.IsValid)
            {
                return View(lista);
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String camponombre, String campopw)
        {
            int count = 0;
            this.CrearModelo();
            NewUserModel usuario = new NewUserModel();
            usuario.Nickname = camponombre;
            usuario.Password = campopw;
            IEnumerable<NewUserModel> result =  modelo.VerificarUsuario(usuario);
            usuario = result.FirstOrDefault();
            foreach (var u in result)
            {
                count++;
            }
             
            if (count == 1 )
            {
                
                FormsAuthenticationTicket ticket =
                    new FormsAuthenticationTicket(1, usuario.Name.ToString(), DateTime.Now, DateTime.Now.AddMinutes(15), true, usuario.UserId.ToString(), FormsAuthentication.FormsCookiePath);
                String ticketEncrypted = FormsAuthentication.Encrypt(ticket);
                HttpCookie httpCookie = new HttpCookie("cookiecliente", ticketEncrypted);
                Response.Cookies.Add(httpCookie);
                IEnumerable<Practicas.Models.Roles> userRole = modelo.GetRoleByUserId(usuario.UserId);
                foreach(var user in userRole)
                {
                    String miRol =  user.Role.ToString();
                    TempData["ROL"] ="El usuario es: " + miRol;
                }



                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.res = "Usuario o contraseñas incorrectos";
                ViewBag.color = "Red";
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
        public ActionResult CreateNewUser(NewUserModel model)
        {
            if (ModelState.IsValid)
            {
                this.CrearModelo();
                modelo.InsertarUsuario(model);
                return Redirect("Index");
            }
            return View(model);
        }
    }
}