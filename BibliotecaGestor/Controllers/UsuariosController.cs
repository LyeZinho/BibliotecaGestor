using Microsoft.AspNetCore.Mvc;
using BibliotecaGestor.Models;
using BibliotecaGestor.Models.Database;

namespace BibliotecaGestor.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        // - Criar -
        public IActionResult Criar(int id)
        {
            MySqlConector conector = new MySqlConector();
            database db = new database(
                new UserData(conector.Conection())
            );
            var users = db.Get(id);
            users.Iduser = id;
            return View(users);
        }

        [HttpPost]
        public IActionResult Criar(User user)
        {
            MySqlConector conector = new MySqlConector();
            database db = new database(
                new UserData(conector.Conection())
            );
            db.Insert(user);
            return View();
        }

        // - Editar -
        public IActionResult Editar(int id)
        {
            MySqlConector conector = new MySqlConector();
            database db = new database(
                new UserData(conector.Conection())
            );
            User user = db.Get(id);
            user.Iduser = id;
            return View(user);
        }

        [HttpPost]
        public IActionResult Editar(User user)
        {
            Console.WriteLine("Id: " + user.Iduser);
            Console.WriteLine("Nome: " + user.Name);
            Console.WriteLine("Email: " + user.Email);
            Console.WriteLine("ZipCpde: " + user.ZipCode);

            MySqlConector conector = new MySqlConector();
            database db = new database(
                new UserData(conector.Conection())
            );
            db.Update(user);
            return View();
        }
    }
}
