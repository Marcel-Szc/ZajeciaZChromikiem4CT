using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface ICoffeeMachine
    {
        void AddMilk(int portion);
        void BoilWater(int portion, int temperature);
        void BrewCoffee();
        void ProcessFinished();
        void GroundCoffee(int portion);
        void MakeCoffee(ICoffeeReceipe receipe);
    }
}
