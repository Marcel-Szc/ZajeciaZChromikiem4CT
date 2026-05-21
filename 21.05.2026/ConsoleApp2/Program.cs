namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachine machine = new CoffeeMachine();
            ReceipeEspresso receipeEspresso = new ReceipeEspresso();
            ReceipeWithMilk receipeWithMilk = new ReceipeWithMilk();

            machine.MakeCoffee(receipeWithMilk);
            Console.WriteLine("-------------------------------------------------------------------");
            machine.MakeCoffee(receipeEspresso);
        }
    }
    public class BadCoffeeMachine
    {
        public void MakeCoffee(string name)
        {
            Console.WriteLine($"Making coffee {name}");

            if(name == "WithMilk")
            {
                GroundCoffee(1);
                BoilWater(200, 100);
                BrewCoffee();
                AddMilk(20);
                ProcessFinished();
            } else if (name == "Espresso")
            {
                GroundCoffee(5);
                BoilWater(100, 100);
                BrewCoffee();
                ProcessFinished();
            }

        }
        public void GroundCoffee(int portion)
        {
            Console.WriteLine($"Grounded {portion} portion of coffee");
        }
        public void BoilWater(int portion, int temperature)
        {
            Console.WriteLine($"Boiled {portion} portion of water to {temperature}°C");
        }
        public void BrewCoffee()
        {
            Console.WriteLine("Brew process");
        }
        public void AddMilk(int portion)
        {
            Console.WriteLine($"Added {portion} of Milk");
        }
        public void ProcessFinished()
        {
            Console.WriteLine("Process finished");
        }
    }
    public class CoffeeMachine : ICoffeeMachine
    {
        public void MakeCoffee(ICoffeeReceipe receipe)
        {
            Console.WriteLine($"Making coffee {receipe}");
            receipe.RunReceipe(this); 
        }
        public void GroundCoffee(int portion)
        {
            Console.WriteLine($"Grounded {portion} portion of coffee");
        }
        public void BoilWater(int portion, int temperature)
        {
            Console.WriteLine($"Boiled {portion} portion of water to {temperature}°C");
        }
        public void BrewCoffee()
        {
            Console.WriteLine("Brew process");
        }
        public void AddMilk(int portion)
        {
            Console.WriteLine($"Added {portion} of Milk");
        }
        public void ProcessFinished()
        {
            Console.WriteLine("Process finished");
        }
    }
}