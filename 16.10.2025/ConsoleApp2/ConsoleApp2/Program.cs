
using System.Collections.ObjectModel;

class Program
{
    static void Main(string[] args)
    {
        Zegar zegar = new();
        zegar.Konfiguruj("Alaska", 1);

        Zegar zegar1 = new();
        zegar1.Konfiguruj("Hawaje", 2);

        Console.ReadKey();
    }
}
class Zegar
{
    private string nazwaStrefy;
    private int numerLinii;

    ReadOnlyCollection<TimeZoneInfo> tzi;
    System.Timers.Timer timer;

    public void Konfiguruj(string nazwaStrefy, int numerLinii)
    {
        this.nazwaStrefy = nazwaStrefy;
        this.numerLinii = numerLinii;

        System.Timers.Timer timer;
        timer = new System.Timers.Timer();
        timer.Interval = 1000;
        timer.Elapsed += Timer_Elapsed;
        timer.Start();
    }

    void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        tzi = TimeZoneInfo.GetSystemTimeZones();
        nazwaStrefy = "Alaska";
        numerLinii = 0;
        foreach (TimeZoneInfo timeZone in tzi)
        {
            if (timeZone.DisplayName.IndexOf(nazwaStrefy) > 0)
            {
                Console.SetCursorPosition(0, numerLinii);
                Console.WriteLine($"\r {timeZone.DisplayName} {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                    DateTime.Now,
                    TimeZoneInfo.Local.Id,
                    timeZone.Id
                )}");
            }
        }
    }
}
/*
class Zegar
{
    private string nazwaStrefy;
    private int numerLinii;

    ReadOnlyCollection<TimeZoneInfo> tzi;
    System.Timers.Timer timer;

    public void Config(string nazwaStrefy, int numerLinii) {
        this.nazwaStrefy = nazwaStrefy;
        this.numerLinii = numerLinii;

        timer = new System.Timers.Timer();
        timer.Interval = 1000;
        timer.Elapsed += Timer_Elapsed;
        timer.Start();
    }
    private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        tzi = TimeZoneInfo.GetSystemTimeZones();
        foreach (TimeZoneInfo timeZone in tzi)
        {
            if (timeZone.DisplayName.IndexOf(this.nazwaStrefy) > 0)
            {
                Console.SetCursorPosition(0, numerLinii);
                Console.WriteLine($"\r {timeZone.DisplayName} {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                    DateTime.Now,
                    TimeZoneInfo.Local.Id,
                    timeZone.Id
                )}");
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Zegar zegar = new();
        zegar.Config("Alaska", 0);
        Zegar zegar1 = new();
        zegar1.Config("Hawaje", 1);

    }
} */