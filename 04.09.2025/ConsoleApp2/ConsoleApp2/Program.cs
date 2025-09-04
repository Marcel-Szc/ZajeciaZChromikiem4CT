class Program()
{
    public void WYpiszWKonsoli(string text)
    {
        Console.WriteLine(text);
    }
}
class OperacjeMat()
{
    public int dodawanie(int a, int b)
    {
        return a + b;
    }

    public void odejmowanie(int a, int b)
    {
        Console.WriteLine(a - b);
    }
}
class PolaFigur()
{
    public double poleTrojkata(double a, double h)
    {
        return (a * h) / 2;
    }
    public void poleKwadratu(int a, int b)
    {
        Console.WriteLine(a * b);
    }
}
class Uruchomienie()
{
    static void Main(string[] args)
    {
        // Uruchomienie
        Console.WriteLine("Uruchomione");
        Program program = new(); // To samo co "= new Program()";
        program.WYpiszWKonsoli("AAAAAAAAAAAAA");
        Uruchomienie uruchomienie = new();
        uruchomienie.nazwa();
        // Operacje Matematyczne
        OperacjeMat operacje = new();
        Console.WriteLine(operacje.dodawanie(3, 5));
        operacje.odejmowanie(6, 7);
        // Pola
        PolaFigur pola = new();
        Console.WriteLine(pola.poleTrojkata(6,8));
        pola.poleKwadratu(6, 7);
    }

    void nazwa()
    {
        
    }
}