using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface ICoffeeReceipe
    {
        public void RunReceipe(ICoffeeMachine machine);
    }
}
