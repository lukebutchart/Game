using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    public class Tile
    {
        /// <summary>
        /// The integer value of the tile above.
        /// </summary>
        public int Up { get; set; }

        /// <summary>
        /// The integer value of the tile below.
        /// </summary>
        public int Down { get; set; }

        /// <summary>
        /// The integer value of the tile to the left.
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// The integer value of the tile to the right.
        /// </summary>
        public int Right { get; set; }

        /// <summary>
        /// The integer value of the tile.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// The tile to the right. (null if does not exist)
        /// </summary>
        public Tile TileRight { get; set; }

        /// <summary>
        /// The tile to the left. (null if does not exist)
        /// </summary>
        public Tile TileLeft { get; set; }

        /// <summary>
        /// The tile above. (null if does not exist)
        /// </summary>
        public Tile TileUp { get; set; }

        /// <summary>
        /// The tile below. (null if does not exist)
        /// </summary>
        public Tile TileDown { get; set; }

        /// <summary>
        /// The horizontal position of the tile.
        /// </summary>
        public int xPos { get; set; }

        /// <summary>
        /// The vertical position of the tile.
        /// </summary>
        public int yPos { get; set; }

        /// <summary>
        /// Takes a tile and returns its ASCII representation.
        /// </summary>
        /// <param name="tile">The tile to draw.</param>
        /// <returns>ASCII representation of the given tile.</returns>
        public StringBuilder DrawTile(Tile tile)
        {
            StringBuilder drawnTile = new StringBuilder("   ");

            Tile tileToRight = tile.TileRight;
            Tile tileToLeft = tile.TileLeft;
            Tile tileAbove = tile.TileUp;
            Tile tileBelow = tile.TileDown;

            int leftValue = tile.Left;
            int rightValue = tile.Right;
            int aboveValue = tile.Up;
            int belowValue = tile.Down;

            int value = tile.Value;

            if (value == 1)
            {
                if (leftValue == 0)
                {
                    drawnTile[0] = '|';
                }
                if (rightValue == 0)
                {
                    drawnTile[2] = '|';
                }
                if (belowValue == 0)
                {
                    drawnTile[1] = '_';
                }
                if (belowValue == 0 && leftValue == 1)
                {
                    drawnTile[0] = '_';
                }
                if (belowValue == 0 && rightValue == 1)
                {
                    drawnTile[2] = '_';
                }
            }

            if (value == 0)
            {
                if (belowValue == 1)
                {
                    drawnTile[0] = '_';
                    drawnTile[1] = '_';
                    drawnTile[2] = '_';
                }
                else
                {
                    drawnTile[0] = '*';
                    drawnTile[1] = '*';
                    drawnTile[2] = '*';
                }
            }

            MazeGenerator program = new MazeGenerator();
            List<int> randomArray = new List<int>();
            program.GenerateRandomList(program.listSize, program.treasureChance, randomArray);

            if (value == 1)
            {
                if (leftValue == 1 && rightValue == 1 && belowValue == 1 && aboveValue == 1)
                {
                    int randomInt = new int();

                    randomInt = randomArray[xPos * yPos % program.listSize];

                    if (randomInt == 1)
                    {
                        drawnTile[1] = 'T';
                    }
                }
            }

            return drawnTile;
        }
    }
}