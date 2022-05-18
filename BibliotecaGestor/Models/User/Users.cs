namespace BibliotecaGestor.Models
{
    public class User
    {
        /*
        Desing patterns / SOLID principles:
        1. Builder
        2. SRP (Single Responsibility Principle)
        */
        public int Iduser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string ZipCode { get; set; }

        public User()
        {
            Iduser = 0;
            Name = "";
            Email = "";
            Phone = 0;
            ZipCode = "";
        }

    }
}
