using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Attack { get; set; }
        public int Magic { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; }
        public int Vitality { get; set; }
        public int Perception { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Endurance { get; set; }
        public int Agility { get; set; }
        public List<int> StatRoll { get; set; }
        public List<Ability> AbilityList { get; set; }

        public List<string> maleNames = new List<string>()
        {
            "Barry",
            "Gary",
            "John",
            "David"
        };

        public List<string> femaleNames = new List<string>()
        {
            "Mary",
            "Stephanie",
            "Hannah",
            "Rachel"
        };

        public List<string> genderList = new List<string>()
        {
            "M",
            "F"
        };

        //public List<string> statList = new List<string>()
        //{
        //    "Health",
        //    "Mana",
        //    "Attack",
        //    "Magic",
        //    "Defence",
        //    "Speed"
        //};

        //public List<string> specialList = new List<string>()
        //{
        //    "Vitality",
        //    "Perception",
        //    "Strength",
        //    "Intelligence",
        //    "Endurance",
        //    "Agility"
        //};

        //public List<int> specialMultList = new List<int>()
        //{
        //    10,
        //    10,
        //    5,
        //    5,
        //    4,
        //    3
        //};

        enum specialEnums       //THESE CANNOT BE EQUAL VALUES. IT WILL BREAK A LOT. MUST BE ALPHABETICAL.
        {
            Agility = 3,
            Endurance = 4,
            Intelligence = 5,
            Strength = 6,
            Vitality = 10,
            Perception = 15
        };

        /// <summary>
        /// Returns the value of an enum at the given index.
        /// </summary>
        /// <param name="specialOrStat">Pass string "Special" or "Stat" to specify which enum to look at.</param>
        /// <param name="index">The index of the enum to look at.</param>
        /// <returns>The value of the enum in the given position.</returns>
        public int GetValueFromEnum(string specialOrStat, int index)
        {
            int returnValue;
            string returnName;


            SecretEnumInformation(specialOrStat, index, out returnValue, out returnName);

            return returnValue;
        }

        /// <summary>
        /// Returns the name of an enum at the given index.
        /// </summary>
        /// <param name="specialOrStat">Pass string "Special" or "Stat" to specify which enum to look at.</param>
        /// <param name="index">The index of the enum to look at.</param>
        /// <returns>The name of the enum in the given position.</returns>
        public string GetNameFromEnum(string specialOrStat, int index)
        {
            int returnValue;
            string returnName;
            

            SecretEnumInformation(specialOrStat, index, out returnValue, out returnName);

            return returnName;
        }

        private static void SecretEnumInformation(string specialOrStat, int index, out int returnValue, out string returnName)
        {
            string[] nameArray;
            int[] valArray;

            if (specialOrStat == "Special" || specialOrStat == "special")
            {
                nameArray = Enum.GetNames(typeof(specialEnums));
                valArray = (int[])Enum.GetValues(typeof(specialEnums));
                returnName = nameArray[index];
                returnValue = valArray[index];
            }
            else if (specialOrStat == "Stat" || specialOrStat == "stat" || specialOrStat == "Stats" || specialOrStat == "stats")
            {
                nameArray = Enum.GetNames(typeof(statEnums));
                valArray = (int[])Enum.GetValues(typeof(statEnums));
                returnName = nameArray[index];
                returnValue = valArray[index];
            }
            else
            {
                returnName = "";
                returnValue = 0;
            }
        }

        enum statEnums          //WORK IN PROGRESS   MUST BE ALPHABETICAL.
        {
            Attack,
            Defence,
            Health,
            Magic,
            Mana,
            Speed
        };


        public void GenerateStats(Person person, List<int> randomSeed)
        {
            person.Attack = person.Strength * (int)(specialEnums.Strength) + person.StatRoll[(int)statEnums.Attack];
            person.Defence = person.Endurance * (int)(specialEnums.Endurance) + person.StatRoll[(int)statEnums.Defence];
            person.Health = person.Vitality * (int)(specialEnums.Vitality) + person.StatRoll[(int)statEnums.Health];
            person.Magic = person.Intelligence * (int)(specialEnums.Intelligence) + person.StatRoll[(int)statEnums.Magic];
            person.Mana = person.Perception * (int)(specialEnums.Perception) + person.StatRoll[(int)statEnums.Mana];
            person.Speed = person.Agility * (int)(specialEnums.Agility) + person.StatRoll[(int)statEnums.Speed];
            Console.WriteLine();
        }


        /// <summary>
        /// Returns a person with a new random name for them based on gender. (can be used to clone a person with a new name if 'clone' bool is supplied)
        /// </summary>
        /// <param name="person">The person to give a new random name.</param>
        /// <param name="clone">If 'true' the person's previous name will not be re-chosen.</param>
        /// <returns>A clone of the input person with a new randomised name.</returns>
        public void GenerateName(Person person, List<int> randomSeed, bool clone = false)
        {
            List<string> nameList;
            int nameCount;
            Rand rand = new Rand();
            string name;

            if (person.Gender == "M" || person.Gender == "m")
            {
                nameList = maleNames;
            }
            else if (person.Gender == "F" || person.Gender == "f")
            {
                nameList = femaleNames;
            }
            else
            {
                nameList = maleNames;
                nameList.AddRange(femaleNames);
            }

            if (clone && person.Name != null)
            {
                nameList.Remove(person.Name);
            }

            nameCount = nameList.Count();

            name = nameList[rand.GetRandomInt(randomSeed, nameCount)];

            person.Name = name;
        }

        public void GenerateGender(Person person, List<int> randomSeed)
        {
            int genderCount = genderList.Count();

            Rand rand = new Rand();

            person.Gender = genderList[rand.GetRandomInt(randomSeed, genderCount)];
        }

        public void GenerateSpecial(Person person, List<int> randomSeed, Data data)
        {
            Rand rand = new Rand();
            int specialBase = int.Parse(data.GetData(data.GenerationNumbers, "SpecialBase"));
            int specialRollVariance = int.Parse(data.GetData(data.GenerationNumbers, "SpecialRollVariance"));

            person.Agility = specialBase + rand.GetRandomInt(randomSeed, specialRollVariance);
            rand.RefreshRandomSeed(randomSeed, 1);
            person.Endurance = specialBase + rand.GetRandomInt(randomSeed, specialRollVariance);
            rand.RefreshRandomSeed(randomSeed, 1);
            person.Intelligence = specialBase + rand.GetRandomInt(randomSeed, specialRollVariance);
            rand.RefreshRandomSeed(randomSeed, 1);
            person.Strength = specialBase + rand.GetRandomInt(randomSeed, specialRollVariance);
            rand.RefreshRandomSeed(randomSeed, 1);
            person.Vitality = specialBase + rand.GetRandomInt(randomSeed, specialRollVariance);
            rand.RefreshRandomSeed(randomSeed, 1);
            person.Perception = specialBase + rand.GetRandomInt(randomSeed, specialRollVariance);
            rand.RefreshRandomSeed(randomSeed, 1);
        }

        public void GenerateStatRoll(Person person, List<int> randomSeed, Data data)
        {
            Rand rand = new Rand();
            int statRollVariance = int.Parse(data.GetData(data.GenerationNumbers, "StatRollVariance"));


            if (person.StatRoll == null)
            {
                person.StatRoll = new List<int>();
            }

            for (int i = 0; i < Enum.GetNames(typeof(statEnums)).Length ; i++)
            {
                if (person.StatRoll.Count <= i)
                {
                    person.StatRoll.Add(0);
                }

                person.StatRoll[i] = rand.GetRandomInt(randomSeed, statRollVariance * 2) - statRollVariance;
                rand.RefreshRandomSeed(randomSeed, 1);
            }
        }

        //public void GenerateAbilities(Person person, List<int> randomSeed)
        //{
        //    Rand rand = new Rand();
        //    PersonGenerator personGen = new PersonGenerator();

        //    person.AbilityList.Add()
        //}

        public void GenerateClass(Person person, string className)
        {

        }

        public string[] GiveSpecialList()
        {
            return Enum.GetNames(typeof(specialEnums));
        }

        public string[] GiveStatList()
        {
            return Enum.GetNames(typeof(statEnums));
        }
    }
}