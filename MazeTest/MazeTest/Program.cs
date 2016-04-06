using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            //MazeGenerator instance = new MazeGenerator();

            //PersonGenerator personGen = new PersonGenerator();

            //personGen.Run();

            //instance.Run();            

            AbilityGenerator abilityGen = new AbilityGenerator();

            abilityGen.Run(abilityGen);            
        }
    }
}