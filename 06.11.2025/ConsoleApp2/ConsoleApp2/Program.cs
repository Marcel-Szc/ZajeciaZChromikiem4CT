using System.Timers;

class Program
{
    internal static object Keys = new();

    internal static int counter = 0;
    static void Main()
    {
        Counter[] counters = new Counter[5];
        for (int i = 1; i <= 5; i++) 
        {
            counters[i-1] = new Counter(i);
        }
        

        Console.ReadKey();
    }
}
class Counter
{
    private System.Timers.Timer timer;
    private int wiersz = 0;
    public Counter(int wiersz)
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
        lock (Program.Keys)
        {
            Program.counter++;
            Console.SetCursorPosition(0, wiersz);
            Console.WriteLine($"NR Obiektu: {wiersz}: {Program.counter}");
        }
    }
}
