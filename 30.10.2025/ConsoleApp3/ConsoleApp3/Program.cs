public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Podaj tekst: ");
        string tekst = Console.ReadLine();
        Console.Write("\nPodaj liczbe: ");
        int ileSpacji = Convert.ToInt32(Console.ReadLine());

        Program program = new Program();
        program.Spacje(tekst, ileSpacji);
    }
    private void Spacje(string text, int how_much)
    {
        Spacing spacing = new Spacing(how_much, text);

        Console.WriteLine(spacing.Spacje());
    }
}
public class Spacing
{
    private string text;
    private int iloscSpacji;

    public Spacing(int iloscSpacji, string text)
    {
        this.iloscSpacji = iloscSpacji;
        this.text = text;
    }

    public string Spacje()
    {
        string wynik = "";
        for (int i = 1; i <= this.text.Length; i++)
        {
            if(i % iloscSpacji == 0)
            {
                wynik += $"{this.text[i-1]} ";
            }
        }
        return $"Podany tekst w co {this.iloscSpacji} liter: {wynik}";
    }
}