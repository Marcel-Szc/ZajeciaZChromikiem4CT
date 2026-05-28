using System;
namespace ConsoleApp1.Zly_kod
{
    public class Program
    {

    }
    public class Bird
    {

    }
    public class Dove : Bird
    {
        public void Fly()
        {
            Console.WriteLine("Dove is flyin");
        }
    }
    public class Penguin : Bird
    {
        public void Fly()
        {
            Console.WriteLine("Penguin doesn't fly");
        }
    }
}