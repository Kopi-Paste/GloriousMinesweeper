using System;
using System.Collections.Generic;
using System.Text;

namespace GloriousMinesweeper
{
    class Game
    {
        public int HorizontalTiles { get; }
        public int VerticalTiles { get; }

        public int Mines { get; }

        public ConsoleColor Cover { get; private set; }
        public ConsoleColor CoverSecondary { get; private set; }
        
        public ConsoleColor Uncover { get; private set; }

        public ConsoleColor UncoverSecondary { get; private set; }
        public ConsoleColor Highlight { get; private set; }
        public ConsoleColor Flag { get; private set; }
        public ConsoleColor Text { get; private set; }

        public Tile[,] Minefield { get; set; } 


        public Game(int[] parameters)
        {
            HorizontalTiles = parameters[0];
            VerticalTiles = parameters[1];
            Mines = parameters[2];
            Cover = (ConsoleColor)parameters[3];
            CoverSecondary = (ConsoleColor)parameters[4];
            Uncover = (ConsoleColor)parameters[5];
            UncoverSecondary = (ConsoleColor)parameters[6];
            Highlight = (ConsoleColor)parameters[7];
            Flag = (ConsoleColor)parameters[8];
            Text = (ConsoleColor)parameters[9];
            Minefield = new Tile[HorizontalTiles, VerticalTiles];

            int remainingMines = Mines;
            ConsoleColor currentColour = Cover;

            for (int x = 0; x != HorizontalTiles; x++)
            {
                if (x % 2 == 0)
                    currentColour = Cover;
                else
                    currentColour = CoverSecondary;

                    for (int y = 0; y != VerticalTiles; y++)
                    {
                        Minefield[x, y] = new CoveredTile(remainingMines, (HorizontalTiles - x) * (VerticalTiles - y), currentColour, (Console.WindowWidth - HorizontalTiles + 4 * x) / 2,  (Console.WindowHeight - VerticalTiles + 2 * y) / 2, x, y);
                        if (Minefield[x, y].Mine)
                            remainingMines--;
                        if (currentColour == Cover)
                            currentColour = CoverSecondary;
                        else
                            currentColour = Cover;
                    }
            }


        }
        public void TilesAndMinesCalculator()
        {
            for (int x = 0; x != HorizontalTiles; x++)
                for (int y = 0; y != VerticalTiles; y++)
                    Minefield[x, y].TilesAroundCalculator(x, y);
            foreach (Tile tile in Minefield)
                tile.MinesAroundCalculator();
        }
    }
}
