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

            ability = GetAbility("Lightning", 5, data);

            ability.ReportAbility(ability);
        }

        public Ability GetAbility(string abilityName, int abilityLevel, Data data)
        {
            Ability ability = new Ability();
            string abilityRefName = abilityLevel.ToString() + abilityName;

            foreach (Ability abilityCheck in data.Abilities.AbilityList)
            {
                if (abilityRefName == abilityCheck.RefName)
                {
                    return abilityCheck;
                }
            }
            return ability.GetNewAbility(abilityName, abilityLevel,data);
        }

        public void InstantiateAbilities(Data data)
        {
            Ability ability = new Ability();
            data.Abilities.AbilityList = new List<Ability>();
            List<string> uniqueAbilities = data.Abilities.UniqueAbilities;
                                    
            foreach (string abilityName in uniqueAbilities)
            {
                if (abilityName != "")
                {
                    for (int abilityLevel = 1; abilityLevel <= data.Abilities.HighestLevel; abilityLevel++)
                    {
                        ability = ability.GetNewAbility(abilityName, abilityLevel, data);
                        data.Abilities.AbilityList.Add(ability);
                    }
                }                
            }
        }
    }
}
