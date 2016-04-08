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
            UI ui = new UI();
            Logic logic = new Logic();

            if (initialCheck.allChecks())
            {
                Console.WriteLine("All checks passed.");
                Console.WriteLine();
            }


            //abilityGen.Run(abilityGen, data);
            //classesGen.Run(classesGen, data);

            Initialise(abilityGen, classesGen, data);

            @class = @class.GetNewClass("Barbarian", data);

            Console.WriteLine(@class.Name);
            Console.WriteLine(@class.Weapon);

            Console.WriteLine();

            personGen.Run(data);

            //instance.Run();

            logic.Run(data, ui);
        }

        private static void Initialise(AbilityGenerator abilityGen, ClassesGenerator classesGen, Data data)
        {
            data.InstantiateData();
            abilityGen.InstantiateAbilities(data);
            classesGen.InstantiateClasses(data);
        }
    }
}