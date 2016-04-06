using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class AbilityGenerator
    {
        /// <summary>
        /// The list of all abilities to be instantiated.
        /// </summary>
        public List<string> AbilityNameList { get; set; } = new List<string>()
        {
            "Freeze",
            "Fireball",
            "Shock",
            "Blizzard"
        };
        /// <summary>
        /// The highest level of every ability.
        /// </summary>
        public int HighestAbilityLevel { get; set; } = 5;
        public List<Ability> AbilityList { get; set; }

        public void Run(AbilityGenerator abilityGen)
        {
            InstantiateAbilities();

            Ability ability = new Ability();

            ability = GetAbility("Blizzard", 5);

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

        public void InstantiateAbilities()
        {
            Ability ability = new Ability();
            AbilityList = new List<Ability>();

            foreach (string abilityName in AbilityNameList)
            {
                for (int abilityLevel = 1; abilityLevel <= HighestAbilityLevel; abilityLevel++)
                {
                    ability = ability.GetNewAbility(abilityName, abilityLevel);
                    AbilityList.Add(ability);
                }
            }
        }
    }
}
