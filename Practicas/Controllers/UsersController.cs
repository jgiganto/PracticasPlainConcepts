using Practicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            ViewBag.res = "Mensaje de verificación";
            ViewBag.color = "blue";
            this.CrearModelo();
            List<NewUserModel> lista = modelo.GetUsuarios();
            if (ModelState.IsValid)
            {
                return View(lista);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Login(String camponombre, String campopw)
        {
            this.CrearModelo();
            NewUserModel usuario = new NewUserModel();
            usuario.Nickname = camponombre;
            usuario.Password = campopw;
            IEnumerable<NewUserModel> result =  modelo.VerificarUsuario(usuario);
            int num = Enumerable.Cast<int>(result).ToString().Count(); 

            if ( num != 1  )
            {
                ViewBag.res = "Usuario correcto";
                ViewBag.color = "green";
                return View("Index");
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