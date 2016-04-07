using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class InitialChecks
    {
        public string[] specialCheckList { get; set; } =
        {
            "Agility",
            "Endurance",
            "Intelligence",
            "Strength",
            "Vitality",
            "Perception"
        };

        public string[] statCheckList { get; set; } =
        {
            "Attack",
            "Defence",
            "Health",
            "Magic",
            "Mana",
            "Speed"
        };

        /// <summary>
        /// Checks that the Special and Stat enums are in the correct order.
        /// </summary>
        /// <returns>'false' if Special and/or Stat enums are inconsistent.</returns>
        public bool statChecks()
        {
            Person person = new Person();

            string[] specialNameList = person.GiveSpecialList();
            string[] statNameList = person.GiveStatList();

            string specialName;
            string statName;

            bool testResult = true;

            for (int i = 0; i < specialNameList.Count(); i++)
            {
                specialName = person.GetNameFromEnum("Special", i);
                if (specialName != specialCheckList[i])
                {
                    testResult = false;
                }
            }

            for (int i = 0; i < statNameList.Count(); i++)
            {
                statName = person.GetNameFromEnum("Stat", i);
                if (statName != statCheckList[i])
                {
                    testResult = false;
                }
            }

            return testResult;
        }

        public bool otherChecks()
        {
            return true;
        }

        public bool allChecks()
        {
            return statChecks() && otherChecks();
        }
    }
}
