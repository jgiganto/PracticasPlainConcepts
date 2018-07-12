﻿using Practicas.Models;
using System.Web.Mvc;

namespace Practicas.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            var model = new UsersModel();
            model.Users.Add(new UserModel
            {
                Name = "Pepe",
                Apellido = "Machado"
                
            });
            return View(model);
        }
    }
}