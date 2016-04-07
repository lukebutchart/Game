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
        public bool Existence { get; set; } = false;
        public int Agility { get; set; }
        public int Endurance { get; set; }
        public int Intelligence { get; set; }
        public int Strength { get; set; }
        public int Vitality { get; set; }
        public int Perception { get; set; }
        public int Sword { get; set; }
        public int Axe { get; set; }
        public int Staff { get; set; }
        public int Bow { get; set; }
        //public string AbilityName1 { get; set; }
        //public string AbilityName2 { get; set; }
        //public string AbilityName3 { get; set; }
        public List<Ability> AbilList { get; set; }


        public Classes GetNewClass(string className, Data data)
        {
            //XMLClass classesXML = new XMLClass();
            Classes @class = new Classes();

            //classesXML.XMLWriteClasses();
            //@class = classesXML.XMLReadClassesReturn(className);


            //CSVClass abilitiesXML = new CSVClass();

            try
            {
                int classIndex = data.GetIndex(data.Classes, "Name", className);

                @class.Name = data.GetData(data.Classes, "Name", classIndex);
                @class.Weapon = data.GetData(data.Classes, "Weapon", classIndex);
                @class.Agility = int.Parse(data.GetData(data.Classes, "Agility", classIndex));
                @class.Endurance = int.Parse(data.GetData(data.Classes, "Endurance", classIndex));
                @class.Intelligence = int.Parse(data.GetData(data.Classes, "Intelligence", classIndex));
                @class.Strength = int.Parse(data.GetData(data.Classes, "Strength", classIndex));
                @class.Vitality = int.Parse(data.GetData(data.Classes, "Vitality", classIndex));
                @class.Perception = int.Parse(data.GetData(data.Classes, "Perception", classIndex));
                @class.Sword = int.Parse(data.GetData(data.Classes, "Sword", classIndex));
                @class.Axe = int.Parse(data.GetData(data.Classes, "Axe", classIndex));
                @class.Staff = int.Parse(data.GetData(data.Classes, "Staff", classIndex));
                @class.Bow = int.Parse(data.GetData(data.Classes, "Endurance", classIndex));

                string abilityName1 = data.GetData(data.Classes, "Ability1", classIndex);
                string abilityName2 = data.GetData(data.Classes, "Ability2", classIndex);
                string abilityName3 = data.GetData(data.Classes, "Ability3", classIndex);

                @class.AbilList = new List<Ability>();

                foreach (Ability ability in data.Abilities.AbilityList)
                {
                    if ((ability.RefName == abilityName1 || ability.RefName == abilityName2 || ability.RefName == abilityName3) && !@class.AbilList.Contains(ability))
                    {
                        @class.AbilList.Add(ability);
                    }
                }               

                @class.Existence = true;

                return @class;
            }
            catch (Exception)
            {
                @class.Existence = false;
                return null;
            }
        }

        public void ReportClass(Classes @class)
        {
            if (@class.Existence)
            {
                Console.WriteLine("Name  : {0}", @class.Name);
                Console.WriteLine("Weapon: {0}", @class.Weapon);
            }
            else
            {
                Console.WriteLine("Class does not exist.");
            }
        }


        //  DEPRECATED
        //public List<int> SpecialBonusList { get; set; }
        //public List<int> WeaponProficiencies { get; set; }
        //public List<string> AbilityList { get; set; }
    }
}
