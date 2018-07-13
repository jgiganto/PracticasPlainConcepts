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
            Uri uri = HttpContext.Request.Url;
            String rutauri = uri.Scheme + "://" + uri.Authority
                + "/Models/usuarios.xml";
            String path =
                HttpContext.Server.MapPath("~/Models/usuarios.xml");
            modelo = new ModeloUsuarios(rutauri, path);
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
            NewUsersModel listausuarios = new NewUsersModel();
            NewUserModel usuario = new NewUserModel();
            usuario.Name = model.Name;
            listausuarios.NewUsers.Add(usuario);
            Session["Datos"] = listausuarios;

            return View();
        }
    }
}