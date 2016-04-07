using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class Ability
    {
        public string RefName { get; set; }
        public string Name { get; set; }
        public string DamageEffect { get; set; }
        public string StatusEffect { get; set; }
        public int Level { get; set; }
        public int Cost { get; set; }
        public int Power { get; set; }
        public bool Existence { get; set; } = false;
        public int MaxLevel { get; set; }


        public Ability GetNewAbility(string abilityName, int abilityLevel)
        {
            XMLClass abilitiesXML = new XMLClass();
            Ability ability = new Ability();

            ability = abilitiesXML.XMLReadAbilitiesReturn(abilityName, abilityLevel);

            if (ability.Name != null && ability.DamageEffect != null && ability.Level != 0)
            {
                ability.RefName = ability.Level.ToString() + ability.Name;
                ability.Existence = true;
            }
            else
            {
                ability.Existence = false;
            }

            return ability;
        }

        public void ReportAbility(Ability ability)
        {
            if (ability.Existence)
            {
                Console.WriteLine("RefNam: {0}", ability.RefName);

                Console.WriteLine("Name  : {0}", ability.Name);
                Console.WriteLine("DamEff: {0}", ability.DamageEffect);
                Console.WriteLine("StaEff: {0}", ability.StatusEffect);
                Console.WriteLine("Level : {0}", ability.Level);
                Console.WriteLine("Cost  : {0}", ability.Cost);
                Console.WriteLine("Power : {0}", ability.Power);
            }
            else
            {
                Console.WriteLine("Ability does not exist.");
            }
        }
    }
}
