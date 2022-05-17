namespace BibliotecaGestor.Models.Withdraw
{
    public class Whitdraw
    {
        private int Id = 0;
        private int IdUser = 0;
        private int IdBook = 0;
        private string Date = "";
        
        public int GetId() 
        {
            return Id;
        }
        public int GetIdUser()
        {
            return IdUser;
        }
        public int GetIdBook()
        {
            return IdBook;
        }
        public string GetDate()
        {
            return Date;
        }

        public Whitdraw SetUserid(int id)
        {
            IdUser = id;
            return this;
        }
        public Whitdraw SetWhitdrawid(int id)
        {
            Id = id;
            return this;
        }
        public Whitdraw SetBookid(int id)
        {
            IdBook = id;
            return this;
        }
        public Whitdraw SetDate()
        {
            Date = DateTime.Now.ToString("[ yyyy-MM-dd | HH:mm:ss ]");
            return this;
        }
        public Whitdraw Build()
        {
            whitdrawAuth auth = new whitdrawAuth();
            auth.SetId(Id).
                 SetIdBook(IdBook).
                 SetIdUser(IdUser);
            
            if (auth.Validate())
            {
                return this;
            }
            return new Whitdraw();
        }
    }

    public class whitdrawAuth : Whitdraw 
    {
        private int _id = 0;
        private int _iduser = 0;
        private int _idbook = 0;

        public whitdrawAuth SetId(int authId)
        {
            _id = authId;
            return this;
        }
        public whitdrawAuth SetIdUser(int authId)
        {
            _iduser = authId;
            return this;
        }
        public whitdrawAuth SetIdBook(int authId)
        {
            _idbook = authId;
            return this;
        }
        public bool Validate()
        {
            if (_id == 0 || _iduser == 0 || _idbook == 0)
            {
                return false;
            }
            return true;
        }
    }
}
