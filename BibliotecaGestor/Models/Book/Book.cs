namespace BibliotecaGestor.Models
{ 
    public class Book
    {
        public int Idbook = 0;
        public string Title = "";
        public string Author = "";
        public string Isbn = "";
        public string Publisher = "";

        public int GetIdBook()
        {
            return Idbook;
        }
        public string GetTitle()
        {
            return Title;
        }
        public string GetAuthor()
        {
            return Author;
        }
        public string GetIsbn()
        {
            return Isbn;
        }
        public string GetPublisher()
        {
            return Publisher;
        }

        public Book SetInfo(string title, string author)
        {
            Title = title;
            Author = author;
            return this;
        }
        public Book SetPublisher(string publisher, string isbn)
        {
            Publisher = publisher;
            Isbn = isbn;
            return this;
        }
        public Book SetId(int id)
        {
            Idbook = id;
            return this;
        }
        public Book Build()
        {
            authBook auth = new authBook().
                SetTitle(Title).
                SetAuthor(Author).
                SetIsbn(Isbn);

            if (auth.Validate())
            {
                return this;
            }
            return new Book();
        }
    }

    public class authBook : Book
    {
        private string _title = "";
        private string _author = "";
        private string _isbn = "";

        public authBook SetTitle(string authTitle)
        {
            _title = authTitle;
            return this;
        }
        public authBook SetAuthor(string authAuthor)
        {
            _author = authAuthor;
            return this;
        }
        public authBook SetIsbn(string authIsbn)
        {
            _isbn = authIsbn;
            return this;
        }
        public bool Validate()
        {
            if (
                string.IsNullOrEmpty(_title) ||
                string.IsNullOrEmpty(_author) ||
                string.IsNullOrEmpty(_isbn)
               )
            {
                return false;
            }
            return true;
        }
    }
}