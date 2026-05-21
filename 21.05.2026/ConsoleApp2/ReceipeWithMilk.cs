using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ReceipeWithMilk : ICoffeeReceipe
    {
        public void RunReceipe(ICoffeeMachine machine)
        {
            machine.GroundCoffee(1);
            machine.BoilWater(200, 100);
            machine.BrewCoffee();
            machine.AddMilk(20);
            machine.ProcessFinished();
        }
    }
}
