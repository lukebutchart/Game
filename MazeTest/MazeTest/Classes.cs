using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class Classes
    {
        public string Name { get; set; }
        public string Weapon { get; set; }
        public List<int> SpecialBonusList { get; set; }
        public List<int> WeaponProficiencies { get; set; }
        public List<string> AbilityList { get; set; }
        public bool Existence { get; set; } = false;


        public Classes GetNewClass(string className)
        {
            XMLClass classesXML = new XMLClass();
            Classes @class = new Classes();

            //classesXML.XMLWriteClasses();
            @class = classesXML.XMLReadClassesReturn(className);


            if (@class.Name != null && @class.Weapon != null)
            {
                @class.Existence = true;
            }
            else
            {
                @class.Existence = false;
            }

            return @class;
        }

        public void ReportClass(Classes @class)
        {
            if (@class.Existence)
            {
                Console.WriteLine("Name  : {0}", @class.Name);
                Console.WriteLine("Weapon: {0}", @class.Weapon);
                //Console.WriteLine("StaEff: {0}", @class.StatusEffect);
                //Console.WriteLine("Level : {0}", @class.Level);
                //Console.WriteLine("Cost  : {0}", @class.Cost);
                //Console.WriteLine("Power : {0}", @class.Power);
            }
            else
            {
                Console.WriteLine("Class does not exist.");
            }
        }
    }
}
