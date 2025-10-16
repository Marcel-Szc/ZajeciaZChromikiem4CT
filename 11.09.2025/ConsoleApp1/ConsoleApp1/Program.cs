namespace Kontener1
{
    using Kontener2;
    class Program
    {
        static void Main(string[] args)
        {

            Program program = new Program();
            program.Odejmowanie(4, 1);
            program.WykonajOdejmowanie(6, 5);


            Dodawanie dodawanie = new();
            dodawanie.Dodaj(6, 7);

            Kontener2.Program program1 = new Kontener2.Program();
            program1.Wypis("AAAAAAAAAAAAAAAAAAAA");
        }


        public void WykonajOdejmowanie(int x, int y)
        {
            Odejmowanie(x,y);
        }
        public void Odejmowanie(int a, int b)
        {
          Console.WriteLine(a-b);
        }
    }
}
namespace Kontener2
{
    class Program
    {
        public void Wypis(string text)
        {
            Console.WriteLine(text);
        }
    }
    class Dodawanie
    {
        public void Dodaj(int a, int b)
        {
            Console.WriteLine(a+b);
        }
    }
}