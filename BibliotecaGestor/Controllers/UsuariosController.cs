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


        public IActionResult Criar(int id)
        {
            MySqlConector conector = new MySqlConector();
            database db = new database(
                new UserData(conector.Conection())
            );
            var users = db.Get(id);
            return View(users);
        }

        [HttpPost]
        public IActionResult Criar(User user)
        {
            return View();
        }
    }
}
