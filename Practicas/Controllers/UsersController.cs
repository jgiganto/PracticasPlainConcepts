using Practicas.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
 

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
            this.CrearModelo();
            List<NewUserModel> lista = modelo.GetUsuarios();  
            return View(lista);
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
                modelo.InsertarUsuario(model.Nombre);
                return Redirect("Index");
            }
            return View(model);
        }
    }
}