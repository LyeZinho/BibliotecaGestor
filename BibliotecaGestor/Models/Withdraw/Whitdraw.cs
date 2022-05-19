namespace BibliotecaGestor.Models
{
    public class Wihtdraw
    {
        public int Idwithdraw { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public string Date { get; set; }

        public Wihtdraw()
        {
            Idwithdraw = 0;
            IdUser = 0;
            IdBook = 0;
            Date = "";
        }
    }
}
