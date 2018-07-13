using Practicas.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Practicas.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            //var model = new UsersModel();
            //model.Users.Add(new UserModel
            //{
            //    Name = "Pepe",
            //    Address = "mi casa",              
            //    Lastname = "Machado",
            //    Country="España",
            //    Password="123",
            //    Nickname="pepillo"

            //});
            NewUsersModel usuarios;
                    usuarios =  (NewUsersModel)TempData["Datos"];
            


            return View(usuarios);
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
            TempData["Datos"] = listausuarios;

            return RedirectToAction("Index");
        }
    }
}