namespace BibliotecaGestor.Models 
{ 
    public class Delivery
    {
        public int Iddelivery { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public string Date { get; set; }

        Delivery()
        {
            Iddelivery = 0;
            IdUser = 0;
            IdBook = 0;
            Date = "";
        }
    }
}
