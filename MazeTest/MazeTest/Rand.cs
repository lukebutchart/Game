using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class Rand
    {
        public int randomChance1 = 3;

        public List<int> randomList1 = new List<int>();

        /// <summary>
        /// Initialises all random lists.
        /// </summary>
        /// <param name="spawnListSize">The required list length for changeChance.</param>
        private void InitialiseRandomLists(int spawnListSize)
        {
            GenerateRandomList(spawnListSize, randomChance1, randomList1);
        }

        /// <summary>
        /// Fills a list with 'listSize' many random integers between 0 and 'maxChance' - 1.
        /// </summary>
        /// <param name="listSize">The length of the list to be filled.</param>
        /// <param name="maxChance">Integers are produced at random between 0 and 'maxChance' - 1.</param>
        /// <param name="randomList">The list to be populated with random integers.</param>
        public void GenerateRandomList(int listSize, int maxChance, List<int> randomList)
        {
            Random randomNum = new Random();

            for (int i = 0; i < listSize; i++)
            {
                randomList.Add(randomNum.Next(0, maxChance));
            }
        }

        /// <summary>
        /// Returns a list with 'listSize' many random integers between 0 and 'maxChance' - 1.
        /// </summary>
        /// <param name="listSize">The length of the list to be filled.</param>
        /// <param name="maxChance">Integers are produced at random between 0 and 'maxChance' - 1.</param>
        public List<int> GenerateRandomList(int listSize, int maxChance)
        {
            Random randomNum = new Random();
            List<int> randomList = new List<int>();

            for (int i = 0; i < listSize; i++)
            {
                randomList.Add(randomNum.Next(0, maxChance));
            }

            return randomList;
        }

        /// <summary>
        /// Returns and then removes first value from a list. To be used with GenerateRandomList.
        /// </summary>
        /// <param name="randomList">The list to take values from.</param>
        /// <returns>The first value from the input list.</returns>
        public int GetRandomInt(List<int> randomList)
        {
            int randomNum = new int();

            randomNum = randomList[0];

            randomList.RemoveAt(0);

            return randomNum;
        }

        /// <summary>
        /// Returns and then removes first value from a list. To be used with GenerateRandomList.
        /// </summary>
        /// <param name="randomList">The list to take values from.</param>
        /// <param name="chanceNeeded">The maximum random integer needed.</param>
        /// <returns>The first value from the input list.</returns>
        public int GetRandomInt(List<int> randomList, int chanceNeeded)
        {
            int randomNum = new int();

            randomNum = randomList[0];

            randomList.RemoveAt(0);

            randomNum = randomNum % chanceNeeded;

            return randomNum;
        }

        /// <summary>
        /// Refreshes a random seed by moving a number of entries from the beginning to the end.
        /// </summary>
        /// <param name="randomSeed">The random seed to refresh.</param>
        /// <param name="refreshBy">The number of items to refresh the seed by. (the number of uses the seed most recently had)</param>
        public void RefreshRandomSeed(List<int> randomSeed, int refreshBy)
        {
            for (int i = 0; i < refreshBy; i++)
            {
                randomSeed.Add(randomSeed[0]);
                randomSeed.RemoveAt(0);
            }
        }
    }
}