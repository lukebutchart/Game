using System;
using System.Collections.Generic;
using System.Data;

namespace MazeTest
{
    internal class PersonGenerator
    {
        ///// <summary>
        ///// The variance for each stat when rolling.
        ///// </summary>
        //public int statRollVariance = 5;

        ///// <summary>
        ///// The base value for each Special.
        ///// </summary>
        //public int specialBase = 3;

        ///// <summary>
        ///// The variance for each Special when rolling.
        ///// </summary>
        //public int specialRollVariance = 2;

        public void Run(Data data)
        {
            Rand rand = new Rand();
            List<int> randomSeed = rand.GenerateRandomList(100, 100);

            Person person = new Person();
            Person person1 = new Person();

            person = InstantiatePerson(rand, randomSeed, data);
            //ReportPerson(person);

            person1 = InstantiatePerson(rand, randomSeed, data);
            //ReportPerson(person1);

            //person.GenerateStats1(person, randomSeed);


            Console.WriteLine();
        }

        private Person InstantiatePerson(Rand rand, List<int> randomSeed, Data data)
        {
            Person person = InstantiatePersonProfile(randomSeed);
            rand.RefreshRandomSeed(randomSeed, 9);
            InstantiatePersonData(person, rand, randomSeed, data);
            return person;
        }

        private static void InstantiatePersonData(Person person1, Rand rand, List<int> randomSeed, Data data)
        {
            person1.GenerateStatRoll(person1, randomSeed, data);
            rand.RefreshRandomSeed(randomSeed, 9);
            person1.GenerateSpecial(person1, randomSeed, data);
            rand.RefreshRandomSeed(randomSeed, 9);
            person1.GenerateStats(person1, randomSeed);
        }

        private static void ReportPerson(Person person)
        {
            ReportPersonProfile(person);
            Console.WriteLine();
            ReportPersonSpecial(person);
            Console.WriteLine();
            ReportPersonStats(person);
        }

        private static void ReportPersonSpecial(Person person)
        {
            Console.WriteLine("{1}: {0}", person.Vitality, nameof(person.Vitality));
            Console.WriteLine("{1}: {0}", person.Perception, nameof(person.Perception));
            Console.WriteLine("{1}: {0}", person.Strength, nameof(person.Strength));
            Console.WriteLine("{1}: {0}", person.Intelligence, nameof(person.Intelligence));
            Console.WriteLine("{1}: {0}", person.Endurance, nameof(person.Endurance));
            Console.WriteLine("{1}: {0}", person.Agility, nameof(person.Agility));
        }

        private static void ReportPersonStats(Person person)
        {
            Console.WriteLine("{1}: {0}", person.Health, nameof(person.Health));
            Console.WriteLine("{1}: {0}", person.Mana, nameof(person.Mana));
            Console.WriteLine("{1}: {0}", person.Attack, nameof(person.Attack));
            Console.WriteLine("{1}: {0}", person.Magic, nameof(person.Magic));
            Console.WriteLine("{1}: {0}", person.Defence, nameof(person.Defence));
            Console.WriteLine("{1}: {0}", person.Speed, nameof(person.Speed));
        }

        private static void ReportPersonProfile(Person person)
        {
            Console.WriteLine("{1}: {0}", person.Name, nameof(person.Name));
            Console.WriteLine("{1}: {0}", person.Gender, nameof(person.Gender));
        }

        public Person InstantiatePersonProfile(List<int> randomSeed, string name = "", string gender = "")
        {
            Person person = new Person();

            if (gender == "")
            {
                person.GenerateGender(person, randomSeed);
            }
            else
            {
                person.Gender = gender;
            }

            if (name == "")
            {
                person.GenerateName(person, randomSeed);
            }
            else
            {
                person.Name = name;
            }

            return person;
        }

    }
}