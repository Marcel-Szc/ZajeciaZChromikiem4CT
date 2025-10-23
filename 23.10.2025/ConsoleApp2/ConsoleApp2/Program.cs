namespace Start
{
    using Rachunkowosc;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj wartość netto: ");
            double netto = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Podaj procent podatku: ");
            double procent = Convert.ToDouble(Console.ReadLine());

            Podatek podatek = new Podatek();
            try
            {
                podatek.wartoszc_podatku = procent;
                podatek.wartosc_netto = netto;

                Console.WriteLine($"Wartość brutto: {podatek.ObliczPodatek()}");
            }
            catch (Exception ex) 
            { 
                Console.WriteLine($"Wystąpił błąd:  {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}
namespace Rachunkowosc
{
    class Podatek
    {

        public double wartoszc_podatku {
             get { return _podatek; }
             set {
                 if( value > 0)
                 {
                     _podatek = value;
                 } else
                 {
                     _podatek = value * -1;
                 }
                 
             }
        }
        private double _podatek;

        public double wartosc_netto
        {
            get { return _podatek; }
            set
            {
                if (value > 0)
                {
                    _wartosc_netto = value;
                }
                else if (value < 0)
                {
                    _wartosc_netto = value * -1;
                }
                else
                {
                    throw new ArgumentException("Wartość netto nie może być 0!");
                }
            }
        }
        private double _wartosc_netto;
        public double ObliczPodatek()
        {
            double brutto = _wartosc_netto + ((_wartosc_netto / 100) * _podatek);

            return brutto;
        }
    }
}