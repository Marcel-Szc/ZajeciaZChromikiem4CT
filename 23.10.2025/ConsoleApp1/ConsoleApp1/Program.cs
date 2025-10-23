namespace ProgramStart
{
    using Figury;
    class Program
    {
        static void Main(string[] args)
        {
            //Zaimportowany kontener poprzez using
            Kwadrat kwadrat = new Kwadrat();
            kwadrat.bok = 12;
            kwadrat.obwod = 10;
            Console.WriteLine(kwadrat.obwod);
            kwadrat.obwod = 0;
            Console.ReadLine();
            
            //Bez importowania kontenera
            Bryly.Szescian szescian = new Bryly.Szescian();
        }
    }
}
namespace Bryly
{
    class Szescian
    {

    }
}
namespace Figury
{
    class Kwadrat
    {
        public int bok; //ten sposób jest najmniej zalecany

        public int obwod { 
            get {
                return _obwod; 
            } 
            set { 
                if(value < 0)
                {
                    _obwod = value * -1;
                } else if(value == 0){
                    throw new ArgumentException("Nie może być zerem");
                }
                else
                {
                    _obwod = value;
                } 
            } 
        }

        private int _obwod;
        public void ObliczPole(int a)
        {
            
        }
    }
}
