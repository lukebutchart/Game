using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Maze
    {
        /// <summary>
        /// The integer matrix representing a maze.
        /// </summary>
        public int[,] TilesIntMatrix { get; set; }

        /// <summary>
        /// The height of a maze.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The width of a maze.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The number of tile spaces in a maze.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The total potential area a maze could occupy.
        /// </summary>
        public int Area { get; set; }

        /// <summary>
        /// The percentage of filled area in a maze.
        /// </summary>
        public float FilledPercent { get; set; }

        /// <summary>
        /// The Tile matrix representing a maze.
        /// </summary>
        public Tile[,] TilesTileMatrix { get; set; }

        /// <summary>
        /// Returns a 'drawnMaze' of a maze in its visual representation.
        /// </summary>
        /// <param name="maze">The maze to draw.</param>
        /// <returns>The maze in its visual representation.</returns>
        public List<string> DrawMaze(Maze maze)
        {
            List<string> drawnMaze = new List<string>();

            StringBuilder drawnTile = new StringBuilder();

            Tile tile = new Tile();

            for (int j = 0; j < maze.Height; j++)
            {
                drawnMaze.Add("");
                for (int i = 0; i < maze.Width; i++)
                {
                    tile = maze.TilesTileMatrix[j, i];

                    drawnTile = tile.DrawTile(tile);

                    drawnMaze[j] += drawnTile;
                }
            }

            return drawnMaze;
        }

        /// <summary>
        /// Sets the tile information for the tile in the given position of the given maze.
        /// </summary>
        /// <param name="maze">The maze the tile belongs to.</param>
        /// <param name="x">The horizontal position of the tile.</param>
        /// <param name="y">The vertical position of the tile.</param>
        /// <returns>A full-information tile from the given position.</returns>
        public Tile SetTileInformation(Maze maze, int x, int y)
        {
            Tile tile = new Tile();

            try
            {
                tile.Left = maze.TilesIntMatrix[y, x - 1];
            }
            catch (IndexOutOfRangeException)
            {
                tile.Left = 0;
            }
            try
            {
                tile.Right = maze.TilesIntMatrix[y, x + 1];
            }
            catch (IndexOutOfRangeException)
            {
                tile.Right = 0;
            }
            try
            {
                tile.Up = maze.TilesIntMatrix[y - 1, x];
            }
            catch (IndexOutOfRangeException)
            {
                tile.Up = 0;
            }
            try
            {
                tile.Down = maze.TilesIntMatrix[y + 1, x];
            }
            catch (IndexOutOfRangeException)
            {
                tile.Down = 0;
            }

            tile.Value = maze.TilesIntMatrix[y, x];

            tile.xPos = x;

            tile.yPos = y;

            return tile;
        }

        /// <summary>
        /// Sets the adjacent-tile information on a given tile from a given maze at a given position.
        /// </summary>
        /// <param name="maze">The maze the tile belongs to.</param>
        /// <param name="tile">The tile to find information for.</param>
        /// <param name="x">The horizontal position of the tile.</param>
        /// <param name="y">The vertical position of the tile.</param>
        /// <returns></returns>
        public Tile GetAdjTileInfo(Maze maze, Tile tile, int x, int y)
        {
            try
            {
                tile.TileUp = maze.TilesTileMatrix[y - 1, x];
            }
            catch (IndexOutOfRangeException)
            {
                tile.TileUp = null;
            }
            try
            {
                tile.TileDown = maze.TilesTileMatrix[y + 1, x];
            }
            catch (IndexOutOfRangeException)
            {
                tile.TileDown = null;
            }
            try
            {
                tile.TileLeft = maze.TilesTileMatrix[y, x - 1];
            }
            catch (IndexOutOfRangeException)
            {
                tile.TileLeft = null;
            }
            try
            {
                tile.TileRight = maze.TilesTileMatrix[y, x + 1];
            }
            catch (IndexOutOfRangeException)
            {
                tile.TileRight = null;
            }

            return tile;
        }
    }
}