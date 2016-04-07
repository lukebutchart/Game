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



        public void Run(ClassesGenerator classesGen)
        {
            InstantiateClasses();

            Classes @class = new Classes();

            @class = GetClasses("Barbarian");

            @class.ReportClass(@class);
        }

        public void InstantiateClasses()
        {
            Classes @class = new Classes();
            ClassList = new List<Classes>();

            foreach (string className in ClassNameList)
            {
                @class = @class.GetNewClass(className);
                ClassList.Add(@class);
            }
        }

        public Classes GetClasses(string className)
        {
            Classes @class = new Classes();
            
            foreach (Classes classCheck in ClassList)
            {
                if (className == classCheck.Name)
                {
                    return classCheck;
                }
            }
            return @class.GetNewClass(className);
        }
    }
}