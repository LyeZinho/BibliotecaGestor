namespace BibliotecaGestor.Models
{ 
    public class Book
    {
        public int Idbook { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public string Publisher { get; set; }

        public Book()
        {
            Idbook = 0;
            Title = "";
            Author = "";
            Isbn = "";
            Publisher = "";
        }
    }
}