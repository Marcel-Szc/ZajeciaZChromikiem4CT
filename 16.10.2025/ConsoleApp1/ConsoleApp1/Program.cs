namespace Kontener
{

    public class Program
    {
        static void Main(string[] args)
        {
            MojaKlasa mojaKlasa = new();
            mojaKlasa.MojaMetoda();

            Klasa4TC.MojaMetoda();

        }
    }
    public class MojaKlasa
    {
        // klasie instancjonowanej możemy tworzyć metody zarówno statyczne jak i niestatyczne
        public void MojaMetoda()
        {

        }
        public static void inna()
        {

        }
    }
    public static class Klasa4TC
    {
        // klasy statycznej nie możemy instancjonować
        // W klasie statycznej możemy tworzyć tylko i wyłącznie metody statyczne
        public static void MojaMetoda()
        {

        }
    }
}