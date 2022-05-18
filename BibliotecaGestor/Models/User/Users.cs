namespace BibliotecaGestor.Models
{
    public class User
    {
        /*
        Desing patterns / SOLID principles:
        1. Builder
        2. SRP (Single Responsibility Principle)
        */
        private int Iduser { get; set; }
        private string Name { get; set; }
        private string Email { get; set; }
        private int Phone { get; set; }
        private string ZipCode { get; set; }

        User()
        {
            Iduser = 0;
            Name = "";
            Email = "";
            Phone = 0;
            ZipCode = "";
        }

    }
}
