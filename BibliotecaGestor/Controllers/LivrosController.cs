using Microsoft.AspNetCore.Mvc;
using BibliotecaGestor.Models.Database;
using BibliotecaGestor.Models;

namespace BibliotecaGestor.Controllers
{
    public class LivrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        // - Deletar -
        public IActionResult Deletar(int id)
        {
            MySqlConector conector = new MySqlConector();
            database db = new database(
                new BookData(conector.Conection())
            );
            Book book = db.Get(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Deletar(Book book)
        {
            MySqlConector conector = new MySqlConector();
            database db = new database(
                new BookData(conector.Conection())
            );
            db.Delete(book.Idbook);
            return View();
        }

        
        
        // - Editar -
        public IActionResult Editar(int id)
        {
            MySqlConector conector = new MySqlConector();
            database db = new database(
                new BookData(conector.Conection())
            );
            Book book = db.Get(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Editar(Book book)
        {
            MySqlConector conector = new MySqlConector();
            database db = new database(
                new BookData(conector.Conection())
            );
            db.Update(book);
            return View();
        }
    }
}
