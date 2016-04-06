using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class MazeGenerator
    {
        ///<summary>
        ///Width or height of maze.
        ///</summary>
        public int mazeWidth = 20, mazeHeight = 20;

        ///<summary>
        ///The likelihood that a tile will spawn is 1 divided by spawnChance.
        ///</summary>
        public int spawnChance = 3;

        ///<summary>
        ///The likelihood that a maze will invert or flip is 1 divided by changeChance.
        ///</summary>
        private int changeChance = 2;

        ///<summary>
        ///The likelihood that an empty tile will contain treasure is 1 divided by treasureChance.
        ///</summary>
        public int treasureChance = 6;

        /// <summary>
        /// The length of the initialised random lists.
        /// </summary>
        public int listSize = 100;

        /// <summary>
        /// The minimum percentage of total area that a maze should occupy.
        /// </summary>
        private float minSizePercent = 0.2f;

        /// <summary>
        /// The number of times to try to make a bigger maze.
        /// </summary>
        private int maxGenTries = 10;

        /// <summary>
        /// An integer used to count the number of regeneration tries.
        /// </summary>
        private int numTries = 0;

        /// <summary>
        /// The thickness of the blank-space border around the maze.
        /// </summary>
        public int border = 1;

        /// <summary>
        /// A list of random integers based on spawnChance.
        /// </summary>
        public List<int> randomListSpawn = new List<int>();

        /// <summary>
        /// A list of random integers based on changeChance.
        /// </summary>
        public List<int> randomListChange = new List<int>();

        /// <summary>
        /// A list of random integers based on treasureChance.
        /// </summary>
        public List<int> randomListTreasure = new List<int>();

        /// <summary>
        /// The primary maze.
        /// </summary>
        public Maze maze = new Maze();



        /// <summary>
        /// Runs the program.
        /// </summary>
        public void Run()
        {
            Maze maze;
            List<string> drawnMaze;

            InitialiseRandomLists(mazeWidth * mazeHeight * (maxGenTries + 1));
            InitialiseMaze(out maze, out drawnMaze);

            WriteMaze(drawnMaze);

            ProduceReport(maze);
        }

        /// <summary>
        /// Writes the generated maze to console.
        /// </summary>
        /// <param name="drawnMaze">The maze in 'drawnMaze' format to write to console.</param>
        private static void WriteMaze(List<string> drawnMaze)
        {
            foreach (string line in drawnMaze)
            {
                Console.WriteLine(line);
            }
        }

        /// <summary>
        /// Write a report to console on the maze produced.
        /// </summary>
        /// <param name="maze">The maze to report on.</param>
        private void ProduceReport(Maze maze)
        {
            Console.WriteLine();

            Console.WriteLine("The maze fills {0} out of {1} possible tiles.", maze.Size, maze.Area);

            Console.Write("The maze is {0}% filled.", (int)(maze.FilledPercent * 100));

            if (maze.FilledPercent < minSizePercent)
            {
                Console.WriteLine(" This is lower than the specified {0}%, as it was not large enough after {1} tries.", (int)(minSizePercent * 100), numTries);
            }
            else
            {
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Creates a maze and drawnMaze using set standards. Run before using other maze methods.
        /// </summary>
        /// <param name="maze">The maze to be created.</param>
        /// <param name="drawnMaze">The maze will be 'drawn' here.</param>
        private void InitialiseMaze(out Maze maze, out List<string> drawnMaze)
        {
            maze = new Maze();
            drawnMaze = new List<string>();
            maze = GenerateMaze(mazeHeight, mazeWidth);

            maze = RegenerateMaze(maze);

            drawnMaze = maze.DrawMaze(maze);
        }

        /// <summary>
        /// Initialises all random lists.
        /// </summary>
        /// <param name="spawnListSize">The required list length for changeChance.</param>
        private void InitialiseRandomLists(int spawnListSize)
        {
            GenerateRandomList(spawnListSize, spawnChance, randomListSpawn);
            GenerateRandomList(listSize, changeChance, randomListChange);
            GenerateRandomList(listSize, treasureChance, randomListTreasure);
        }

        /// <summary>
        /// Checks if a maze is filled enough and regenerates it if it is too small.
        /// </summary>
        /// <param name="maze">The maze to check and regenerate.</param>
        /// <returns></returns>
        private Maze RegenerateMaze(Maze maze)
        {
            for (int i = 0; i < maxGenTries; i++)
            {
                if (maze.FilledPercent < minSizePercent)
                {
                    maze = (GenerateMaze(mazeHeight, mazeWidth));
                    numTries++;
                }
            }

            return maze;
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
        /// Returns the inversion of the given maze.
        /// </summary>
        /// <param name="maze">The maze to invert.</param>
        /// <returns>The inverted maze.</returns>
        private Maze InvertMaze(Maze maze)
        {
            int[,] mazeOriginalArray = maze.TilesIntMatrix;

            int[,] mazeNewArray = new int[maze.Width, maze.Height];

            Maze newMaze = new Maze();

            newMaze.Height = maze.Width;

            newMaze.Width = maze.Height;

            newMaze.TilesTileMatrix = new Tile[newMaze.Height, newMaze.Width];

            newMaze.TilesIntMatrix = mazeNewArray;

            for (int i = 0; i < maze.Width; i++)
            {
                for (int j = 0; j < maze.Height; j++)
                {
                    mazeNewArray[i, j] = mazeOriginalArray[j, i];
                }
            }

            newMaze.TilesIntMatrix = mazeNewArray;

            return newMaze;
        }

        /// <summary>
        /// Flips maze on vertical axis.
        /// </summary>
        /// <param name="maze">Maze to be flipped.</param>
        /// <returns>The maze flipped on its vertical axis.</returns>
        private Maze VFlipMaze(Maze maze)
        {
            int[,] mazeOriginalArray = maze.TilesIntMatrix;

            int[,] mazeNewArray = new int[maze.Height, maze.Width];

            Maze newMaze = new Maze();

            newMaze.Height = maze.Height;

            newMaze.Width = maze.Width;

            newMaze.TilesTileMatrix = new Tile[newMaze.Height, newMaze.Width];

            newMaze.TilesIntMatrix = mazeNewArray;

            for (int i = 0; i < maze.Width; i++)
            {
                for (int j = 0; j < maze.Height; j++)
                {
                    mazeNewArray[j, i] = mazeOriginalArray[j, maze.Width - i - 1];
                }
            }

            newMaze.TilesIntMatrix = mazeNewArray;

            return newMaze;
        }

        /// <summary>
        /// Flips maze on horizontal axis.
        /// </summary>
        /// <param name="maze">The maze to be flipped.</param>
        /// <returns>The maze flipped on its horizontal axis.</returns>
        private Maze HFlipMaze(Maze maze)
        {
            int[,] mazeOriginalArray = maze.TilesIntMatrix;

            int[,] mazeNewArray = new int[maze.Height, maze.Width];

            Maze newMaze = new Maze();

            newMaze.Height = maze.Height;

            newMaze.Width = maze.Width;

            newMaze.TilesTileMatrix = new Tile[newMaze.Height, newMaze.Width];

            newMaze.TilesIntMatrix = mazeNewArray;

            for (int i = 0; i < maze.Width; i++)
            {
                for (int j = 0; j < maze.Height; j++)
                {
                    mazeNewArray[j, i] = mazeOriginalArray[maze.Height - j - 1, i];
                }
            }

            newMaze.TilesIntMatrix = mazeNewArray;

            return newMaze;
        }

        /// <summary>
        /// Writes a maze to console in its number representation.
        /// </summary>
        /// <param name="maze">The maze to be written.</param>
        private void PrintMaze(Maze maze)
        {
            for (int i = 0; i < mazeHeight; i++)
            {
                for (int j = 0; j < mazeWidth; j++)
                {
                    Console.Write(maze.TilesIntMatrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Returns a new maze of defined size with a start point in a random corner.
        /// </summary>
        /// <param name="y">The height of the returned maze before a border is added.</param>
        /// <param name="x">The width of the returned maze before a border is added.</param>
        /// <returns></returns>
        public Maze GenerateMaze(int y, int x)
        {
            maze.Height = y + border * 2;

            maze.Width = x + border * 2;

            maze.TilesIntMatrix = new int[maze.Height, maze.Width];

            maze.TilesTileMatrix = new Tile[maze.Height, maze.Width];

            Random rnd = new Random();

            int start = border;

            int left, right, down, up;

            int randomSpawnInteger, randomInvertInteger, randomFlipInteger;

            randomInvertInteger = GetRandomInt(randomListChange);
            randomFlipInteger = GetRandomInt(randomListChange);

            maze.TilesIntMatrix[border + 1, start] = 1;

            for (int j = border; j < maze.Height - 1; j++)
            {
                for (int i = border; i < maze.Width - 1; i++)
                {
                    if (maze.TilesIntMatrix[j, i] != 1)
                    {
                        GetDirections(out left, out right, out down, out up, j, i);

                        if (left == 1 || up == 1)
                        {
                            randomSpawnInteger = GetRandomInt(randomListSpawn);
                            if (randomSpawnInteger != 0)
                            {
                                maze.TilesIntMatrix[j, i] = randomSpawnInteger / randomSpawnInteger;
                            }
                        }
                    }
                }
            }

            if (randomInvertInteger == 0)
            {
                maze = InvertMaze(maze);
            }

            if (randomFlipInteger == 0)
            {
                maze = VFlipMaze(maze);
            }

            if (randomFlipInteger == 0)
            {
                maze = HFlipMaze(maze);
            }

            InstantiateTiles(maze);

            int size = 0;

            for (int i = 0; i < maze.Height; i++)
            {
                for (int j = 0; j < maze.Width; j++)
                {
                    if (maze.TilesIntMatrix[i, j] != 0)
                    {
                        size++;
                    }
                }
            }

            maze.Size = size;

            maze.Area = maze.TilesIntMatrix.Length;

            maze.FilledPercent = (float)maze.Size / (float)maze.Area;

            return maze;
        }

        /// <summary>
        /// Sets the information for all tiles in a given maze.
        /// </summary>
        /// <param name="maze">The maze to set tile information for.</param>
        private void InstantiateTiles(Maze maze)
        {
            int x = maze.Width, y = maze.Height;

            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    maze.TilesTileMatrix[j, i] = maze.SetTileInformation(maze, i, j);
                }
            }

            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    maze.TilesTileMatrix[j, i] = maze.GetAdjTileInfo(maze, maze.TilesTileMatrix[j, i], i, j);
                }
            }
        }

        /// <summary>
        /// Sets value information for adjacent tiles when given a tile location.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="down"></param>
        /// <param name="up"></param>
        /// <param name="j"></param>
        /// <param name="i"></param>
        private void GetDirections(out int left, out int right, out int down, out int up, int j, int i)
        {
            try
            {
                left = maze.TilesIntMatrix[j, i - 1];
            }
            catch (IndexOutOfRangeException)
            {
                left = 0;
            }
            try
            {
                right = maze.TilesIntMatrix[j, i + 1];
            }
            catch (IndexOutOfRangeException)
            {
                right = 0;
            }
            try
            {
                up = maze.TilesIntMatrix[j - 1, i];
            }
            catch (IndexOutOfRangeException)
            {
                up = 0;
            }
            try
            {
                down = maze.TilesIntMatrix[j + 1, i];
            }
            catch (IndexOutOfRangeException)
            {
                down = 0;
            }
        }
    }
}