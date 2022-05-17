namespace BibliotecaGestor.Models.Delivery
{
    public class Delivery
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

        public Delivery SetDeliveryId(int id)
        {
            Id = id;
            return this;
        }
        public Delivery SetUserId(int idUser)
        {
            IdUser = idUser;
            return this;
        }
        public Delivery SetBookId(int idBook)
        {
            IdBook = idBook;
            return this;
        }
        public Delivery SetDate()
        {
            Date = DateTime.Now.ToString("[ yyyy-MM-dd | HH:mm:ss ]");
            return this;
        }
        public Delivery Build()
        {
            authDelivery auth = new authDelivery().
                SetId(Id).
                SetIdUser(IdUser).
                SetIdBook(IdBook);
            
            if (auth.Validate())
            {
                return this;
            }
            return new Delivery();
        }
    }

    public class authDelivery : Delivery
    {
        private int _id = 0;
        private int _idduser = 0;
        private int _idbook = 0;

        public authDelivery SetId(int authId)
        {
            _id = authId;
            return this;
        }
        public authDelivery SetIdUser(int authIdUser)
        {
            _idduser = authIdUser;
            return this;
        }
        public authDelivery SetIdBook(int authIdBook)
        {
            _idbook = authIdBook;
            return this;
        }
        public bool Validate()
        {
            if (_id == 0 || _idduser == 0 || _idbook == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
