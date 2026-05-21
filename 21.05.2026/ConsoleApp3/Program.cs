namespace ConsoleApp3
{
    class MakeCoffee
    {
        public void StartMakingCoffee(string name)
        {
            Console.WriteLine($"Making coffee {name}");

            MachinePrepareCoffee prepareCoffee = new();
            MachineBrewCoffee brewCoffee = new();
            MachineAddMilkToCoffee addMilk = new();

            if (name == "WithMilk")
            {
                prepareCoffee.GroundCoffee(1);
                prepareCoffee.BoilWater(200, 100);
                brewCoffee.BrewCoffee();
                addMilk.AddMilk(20);
                Console.WriteLine("Process finished");
            }
            else if (name == "Espresso")
            {
                prepareCoffee.GroundCoffee(5);
                prepareCoffee.BoilWater(100, 100);
                brewCoffee.BrewCoffee();
                Console.WriteLine("Process finished");
            }
        }
    }
    class MachinePrepareCoffee
    {
        
        public void GroundCoffee(int portion)
        {
            Console.WriteLine($"Grounded {portion} portion of coffee");
        }
        public void BoilWater(int portion, int temperature)
        {
            Console.WriteLine($"Boiled {portion} portion of water to {temperature}°C");
        }
    }
    class MachineBrewCoffee
    {
        public void BrewCoffee()
        {
            Console.WriteLine("Brewing process");
        }
    }
    class MachineAddMilkToCoffee
    {
        public void AddMilk(int portion)
        {
            Console.WriteLine($"Added {portion} of Milk");
        }
    }
    class Program
    {
        static void Main()
        {
            MakeCoffee makeCoffee = new();
            Console.Write("Choose a coffee receipe: ");
            string ReceipeName = Console.ReadLine();
            makeCoffee.StartMakingCoffee(ReceipeName);
        }
    }
}