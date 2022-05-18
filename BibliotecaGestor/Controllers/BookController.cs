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
        
        public IActionResult Edit(int id)
        {
            MySqlConector conector = new MySqlConector();
            database db = new database(new BookData(conector.Conection()));
            Book book = db.Get(id);

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            //MySqlConector conector = new MySqlConector();
            //database db = new database(new BookData(conector.Conection()));
            //db.Update(new Book()
            //{
            //    Idbook = 3,
            //    Title = "c the programing language",
            //    Author = "carlos",
            //    Isbn = "123456789",
            //    Publisher = "Publisher"
            //}
            //);


            //MySqlConector conector = new MySqlConector();
            //database db = new database(
            //    new BookData(conector.Conection())
            //);
            //db.Update(new Book
            //{
            //    Idbook = book.Idbook,
            //    Title = book.Title,
            //    Author = book.Author,
            //    Isbn = book.Isbn,
            //    Publisher = book.Publisher
            //});


            Console.WriteLine("Title: " + book.Title);
            Console.WriteLine("Author: " + book.Author);
            Console.WriteLine("Isbn: " + book.Isbn);
            Console.WriteLine("Publisher: " + book.Publisher);

            return View();
        }
    }
}
