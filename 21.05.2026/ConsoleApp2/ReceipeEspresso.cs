using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ReceipeEspresso : ICoffeeReceipe
    {
        public void RunReceipe(ICoffeeMachine machine)
        {
            machine.GroundCoffee(1);
            machine.BoilWater(100, 100);
            machine.BrewCoffee();
            machine.ProcessFinished();
        }
    }
}
