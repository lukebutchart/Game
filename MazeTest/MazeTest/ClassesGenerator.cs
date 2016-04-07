using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class ClassesGenerator
    {
        public List<string> ClassNameList { get; set; } = new List<string>()
        {
            "Barbarian",
            "Mage"
        };

        public List<Classes> ClassList { get; set; }



        public void Run(ClassesGenerator classesGen, Data data)
        {
            InstantiateClasses(data);

            Classes @class = new Classes();

            @class = GetClasses("Barbarian", data);
            Console.WriteLine();
            @class.ReportClass(@class);
            Console.WriteLine();
        }

        public void InstantiateClasses(Data data)
        {
            Classes @class = new Classes();
            ClassList = new List<Classes>();

            foreach (string className in ClassNameList)
            {
                @class = @class.GetNewClass(className, data);
                ClassList.Add(@class);
            }
        }

        public Classes GetClasses(string className, Data data)
        {
            Classes @class = new Classes();
            
            foreach (Classes classCheck in ClassList)
            {
                if (className == classCheck.Name)
                {
                    return classCheck;
                }
            }
            return @class.GetNewClass(className, data);
        }
    }
}