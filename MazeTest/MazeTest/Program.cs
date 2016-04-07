using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MazeGenerator instance = new MazeGenerator();
            PersonGenerator personGen = new PersonGenerator();
            AbilityGenerator abilityGen = new AbilityGenerator();
            ClassesGenerator classesGen = new ClassesGenerator();
            InitialChecks initialCheck = new InitialChecks();
            XMLClass xmlClass = new XMLClass();
            CSVClass csvClass = new CSVClass();
            Classes @class = new Classes();
            Data data = new Data();

            if (initialCheck.allChecks())
            {
                Console.WriteLine("All checks passed.");
                Console.WriteLine();
            }

            classesGen.Run(classesGen);

            data.InstantiateData();

            Console.WriteLine(@class.Name);
            Console.WriteLine(@class.Weapon);

            Console.WriteLine();

            personGen.Run(data);

            //instance.Run();            
            abilityGen.Run(abilityGen, data);            
        }
    }
}