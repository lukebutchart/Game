using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class AbilityGenerator
    {
        ///// <summary>
        ///// The list of all abilities to be instantiated.
        ///// </summary>
        //public List<string> AbilityNameList { get; set; } = new List<string>()
        //{
        //    "Freeze",
        //    "Fireball",
        //    "Shock",
        //    "Blizzard",
        //    "Lightning",
        //    "Chop",
        //    "Strike"
        //};
        ///// <summary>
        ///// The highest level of every ability.
        ///// </summary>
        //public int HighestAbilityLevel { get; set; } = 5;
        public List<Ability> AbilityList { get; set; }

        public void Run(AbilityGenerator abilityGen, Data data)
        {
            InstantiateAbilities(data);

            Ability ability = new Ability();

            ability = GetAbility("Lightning", 5);

            ability.ReportAbility(ability);
        }

        public Ability GetAbility(string abilityName, int abilityLevel)
        {
            Ability ability = new Ability();
            string abilityRefName = abilityLevel.ToString() + abilityName;

            foreach (Ability abilityCheck in AbilityList)
            {
                if (abilityRefName == abilityCheck.RefName)
                {
                    return abilityCheck;
                }
            }
            return ability.GetNewAbility(abilityName, abilityLevel);
        }

        public void InstantiateAbilities(Data data)
        {
            Ability ability = new Ability();
            AbilityList = new List<Ability>();
            List<string> uniqueAbilities = data.Abilities.UniqueAbilities;
            
            foreach (string abilityName in uniqueAbilities)
            {
                for (int abilityLevel = 1; abilityLevel <= data.Abilities.HighestLevel; abilityLevel++)
                {
                    ability = ability.GetNewAbility(abilityName, abilityLevel);
                    AbilityList.Add(ability);
                }
            }
        }
    }
}
