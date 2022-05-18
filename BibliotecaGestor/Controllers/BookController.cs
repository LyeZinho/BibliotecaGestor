using Microsoft.AspNetCore.Mvc;
using BibliotecaGestor.Models.Database;
using BibliotecaGestor.Models;

namespace BibliotecaGestor.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Editar(int id)
        {
            MySqlConector conector = new MySqlConector();
            database db = new database(new BookData(conector.Conection()));
            Book book = db.Get(id);

            return View(book);
        }
    }
}
