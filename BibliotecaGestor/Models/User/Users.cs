namespace BibliotecaGestor.Models.User
{
    public class User
    {
        /*
        Desing patterns / SOLID principles:
        1. Builder
        2. SRP (Single Responsibility Principle)
        */
        private int Id = 0;
        private string Name = "";
        private string Email = "";
        private int Phone = 0;
        private string ZipCode = "";

        public int GetId()
        {
            return Id;
        }
        public string GetName()
        {
            return Name;
        }
        public string GetEmail()
        {
            return Email;
        }
        public int GetPhone()
        {
            return Phone;
        }
        public string GetZipCode()
        {
            return ZipCode;
        }
        
        public User SetCredentials(string setName, string setEmail)
        {
            this.Name = setName;
            this.Email = setEmail;
            return this;
        }
        public User SetContact(int setPhone)
        {
            this.Phone = setPhone;
            return this;
        }
        public User SetAddress(string setZipCode)
        {
            this.ZipCode = setZipCode;
            return this;
        }
        public User SetId(int setId)
        {
            this.Id = setId;
            return this;
        }
        public User Build()
        {
            userAuth auth = new userAuth().
                SetName(this.Name).
                SetEmail(this.Email).
                SetPhone(this.Phone);
            
            if (auth.Validate())
            {
                return this;
            }
            return new User();
        }
    }

    public class userAuth : User
    {
        private string _name = "";
        private string _email = "";
        private int _phone = 0;

        public userAuth SetPhone(int authPhone)
        {
            _phone = authPhone;
            return this;
        }
        public userAuth SetEmail(string authEmail)
        {
            _email = authEmail;
            return this;
        }
        public userAuth SetName(string authName)
        {
            _name = authName;
            return this;
        }
        public bool Validate()
        {
            if (string.IsNullOrEmpty(_name))
                return false;
            if (string.IsNullOrEmpty(_email))
                return false;
            if (_phone == 0)
                return false;
            return true;
        }
    }
}
