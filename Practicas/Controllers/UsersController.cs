using Practicas.Models;
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
                Address = "mi casa",              
                Lastname = "Machado",
                Country="España",
                Password="123",
                Nickname="pepillo"
                
            });
            model.Users.Add(new UserModel
            {
                Name = "Manuela",
                Address = "mi casa",
                Lastname = "Fuertes",
                Country = "España",
                Password = "123",
                Nickname="manuelilla"
            });
            return View(model);
        }
    }
}