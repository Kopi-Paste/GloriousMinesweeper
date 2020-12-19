using System;
using System.Collections.Generic;
using System.Text;

namespace GloriousMinesweeper
{
    class CoveredTile : Tile
    {
        public CoveredTile(int remainingMines, int remainingTiles, ConsoleColor color, int horizontal, int vertical, int x, int y)
        {
            Random rng = new Random();
            int mineDeterminator = rng.Next(remainingTiles);
            if (mineDeterminator < remainingMines)
                Mine = true;
            else
                Mine = false;
            MinesAround = 0;
            Covered = true;
            Flag = false;
            Color = color;
            TilesAround = new List<Tile>();
            Position = new Coordinates(horizontal, vertical);
            MinefieldPositon = new Coordinates(x, y);
        }

        public override void PrintTile()
        {
            Position.GoTo();
            Console.BackgroundColor = Color;
            Console.Write("  ");
        }
        
    }
}
