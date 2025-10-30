using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.ObliczPOleProstokata();
        Console.ReadKey();
    }
    private void ObliczPOleProstokata()
    {
        double a = 6.7, b = 4.1;
        Prostokat prostokat = new Prostokat(a, b);
        Console.WriteLine(prostokat.WyliczPole());

        double c = 2.1, d = 8.9;
        Prostokat prostokat1 = new Prostokat(c, d);
        Console.WriteLine(prostokat.WyliczPole());
        prostokat = null;
        GC.Collect();
        Console.ReadKey();
    }
}
public class Prostokat
{
    private double bokA;
    private double bokB;

    public Prostokat(double bokA, double bokB)
    {
        this.bokA = bokA;
        this.bokB = bokB;
    }

    public double WyliczPole()
    {
        return this.bokA * this.bokB;
    }
    ~Prostokat()
    {
        Console.WriteLine("Wywołanie destruktora");
    }
}