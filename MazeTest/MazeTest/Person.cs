using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
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
        public Ability AbilityList { get; set; }

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

        public List<string> statList = new List<string>()
        {
            "Health",
            "Mana",
            "Attack",
            "Magic",
            "Defence",
            "Speed"
        };

        public List<string> specialList = new List<string>()
        {
            "Vitality",
            "Perception",
            "Strength",
            "Intelligence",
            "Endurance",
            "Agility"
        };

        public List<int> specialMultList = new List<int>()
        {
            10,
            10,
            5,
            5,
            4,
            3
        };

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

        public void GenerateStats(Person person, List<int> randomSeed)
        {
            int indVitality = person.specialList.IndexOf(nameof(person.Vitality));
            int indPerception = person.specialList.IndexOf(nameof(person.Perception));
            int indStrength = person.specialList.IndexOf(nameof(person.Strength));
            int indIntelligence = person.specialList.IndexOf(nameof(person.Intelligence));
            int indEndurance = person.specialList.IndexOf(nameof(person.Endurance));
            int indAgility = person.specialList.IndexOf(nameof(person.Agility));

            int indHealth = person.statList.IndexOf(nameof(person.Health));
            int indMana = person.statList.IndexOf(nameof(person.Mana));
            int indAttack = person.statList.IndexOf(nameof(person.Attack));
            int indMagic = person.statList.IndexOf(nameof(person.Magic));
            int indDefence = person.statList.IndexOf(nameof(person.Defence));
            int indSpeed = person.statList.IndexOf(nameof(person.Speed));

            person.Health = person.Vitality * person.specialMultList[indVitality] + person.StatRoll[indHealth];
            person.Mana = person.Perception * person.specialMultList[indPerception] + person.StatRoll[indMana];
            person.Attack = person.Strength * person.specialMultList[indStrength] + person.StatRoll[indAttack];
            person.Magic = person.Intelligence * person.specialMultList[indIntelligence] + person.StatRoll[indMagic];
            person.Defence = person.Endurance * person.specialMultList[indEndurance] + person.StatRoll[indDefence];
            person.Speed = person.Agility * person.specialMultList[indAgility] + person.StatRoll[indSpeed];
            Console.WriteLine();
        }

        public void GenerateSpecial(Person person, List<int> randomSeed)
        {
            Rand rand = new Rand();
            PersonGenerator personGen = new PersonGenerator();

            person.Vitality = personGen.specialBase + rand.GetRandomInt(randomSeed, personGen.specialRollVariance);
            rand.RefreshRandomSeed(randomSeed, 1);
            person.Perception = personGen.specialBase + rand.GetRandomInt(randomSeed, personGen.specialRollVariance);
            rand.RefreshRandomSeed(randomSeed, 1);
            person.Strength = personGen.specialBase + rand.GetRandomInt(randomSeed, personGen.specialRollVariance);
            rand.RefreshRandomSeed(randomSeed, 1);
            person.Intelligence = personGen.specialBase + rand.GetRandomInt(randomSeed, personGen.specialRollVariance);
            rand.RefreshRandomSeed(randomSeed, 1);
            person.Endurance = personGen.specialBase + rand.GetRandomInt(randomSeed, personGen.specialRollVariance);
            rand.RefreshRandomSeed(randomSeed, 1);
            person.Agility = personGen.specialBase + rand.GetRandomInt(randomSeed, personGen.specialRollVariance);
            rand.RefreshRandomSeed(randomSeed, 1);
        }

        public void GenerateStatRoll(Person person, List<int> randomSeed)
        {
            PersonGenerator personGen = new PersonGenerator();
            Rand rand = new Rand();

            if (person.StatRoll == null)
            {
                person.StatRoll = new List<int>();
            }

            for (int i = 0; i < statList.Count(); i++)
            {
                if (person.StatRoll.Count <= i)
                {
                    person.StatRoll.Add(0);
                }

                person.StatRoll[i] = rand.GetRandomInt(randomSeed, personGen.statRollVariance * 2) - personGen.statRollVariance;
                rand.RefreshRandomSeed(randomSeed, 1);
            }
        }
    }
}