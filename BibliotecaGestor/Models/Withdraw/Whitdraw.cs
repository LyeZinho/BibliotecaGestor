namespace BibliotecaGestor.Models.Withdraw
{
    public class Whitdraw
    {
        private int Idwithdraw { get; set; }
        private int IdUser { get; set; }
        private int IdBook { get; set; }
        private string Date { get; set; }

        Whitdraw()
        {
            Idwithdraw = 0;
            IdUser = 0;
            IdBook = 0;
            Date = "";
        }
    }
}
