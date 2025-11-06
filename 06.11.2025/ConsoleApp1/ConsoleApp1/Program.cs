using System.Timers;

class Program
{
    internal static int x; // Ta wartość jest dostępna w obrębie jednego tego samego Assembly
    internal static object ConsoleLock = new();
    static void Main()
    {
        /* Zegar zegar0 = new Zegar(1);
        Zegar zegar1 = new Zegar(2);
        Zegar zegar2 = new Zegar(3);
        Zegar zegar3 = new Zegar(4);
        Zegar zegar4 = new Zegar(5);
        */
        
        Zegar[] zegars = new Zegar[5];
        for (int i = 1; i <= zegars.Length; i++) {
            zegars[i-1] = new Zegar(i);
        }
        /*
        List<Zegar> zegary = new List<Zegar>();
        for (int i = 0; i < 5; i++)
        {
            zegary.Add(new Zegar(i));
        }
        */
        Console.ReadKey();
    }
}
class Zegar
{
    private System.Timers.Timer timer;
    private int wiersz = 0;
    public Zegar(int wiersz)
    {
        this.wiersz = wiersz;
        timer = new System.Timers.Timer();
        timer.Interval = 1000;
        timer.Enabled = true;
        timer.Elapsed += Timer_Elapsed;
        timer.Start();
    }

    private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        lock (Program.ConsoleLock)
        {
            Console.SetCursorPosition(0, wiersz);
            Console.WriteLine($"NR Obiektu: {wiersz}: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        }
    }
}
class Lock
{
    private static int counter = 0;
    internal static readonly object CounterLock = new();
    private static void IncrementCounter()
    {
        lock (CounterLock)
        {
            counter++; // W tym miejscu możemy wstawić większą ilość kodu
        }
    }
}
class InterLock
{
    private static int counter = 0;
    private static void IncrementCounter()
    {
        Interlocked.Increment(ref counter); // W tym miejscu możemy zdefiniować jedną funkcjonalność
        
    }
}