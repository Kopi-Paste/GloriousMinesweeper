﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GloriousMinesweeper
{
    abstract class Tile
    {
        public int MinesAround { get; protected set; }
        public bool Covered { get; protected set; }
        public bool Flag { get; protected set; }
        public bool Mine { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        public List<Tile> TilesAround { get; protected set; }
        public Coordinates Position { get; protected set; }
        public Coordinates MinefieldPositon { get; protected set; }

        

        public void TilesAroundCalculator(int horizontal, int vertical)
        {
            if (horizontal != 0)
            {
                TilesAround.Add(GameControls.PlayedGame.Minefield[horizontal - 1, vertical]);
                if (vertical != 0)
                {
                    TilesAround.Add(GameControls.PlayedGame.Minefield[horizontal - 1, vertical - 1]);
                    TilesAround.Add(GameControls.PlayedGame.Minefield[horizontal, vertical - 1]);
                }
                if (vertical != GameControls.PlayedGame.VerticalTiles - 1)
                { 
                    TilesAround.Add(GameControls.PlayedGame.Minefield[horizontal - 1, vertical + 1]);
                    TilesAround.Add(GameControls.PlayedGame.Minefield[horizontal, vertical + 1]);
                }
            }
            if (horizontal != GameControls.PlayedGame.HorizontalTiles - 1)
            {
                TilesAround.Add(GameControls.PlayedGame.Minefield[horizontal + 1, vertical]);
                if (vertical != 0)
                {
                    TilesAround.Add(GameControls.PlayedGame.Minefield[horizontal + 1, vertical - 1]);
                    if (!TilesAround.Contains(GameControls.PlayedGame.Minefield[horizontal, vertical - 1]))
                        TilesAround.Add(GameControls.PlayedGame.Minefield[horizontal, vertical - 1]);
                }   
                if (vertical != GameControls.PlayedGame.VerticalTiles - 1)
                {
                    TilesAround.Add(GameControls.PlayedGame.Minefield[horizontal + 1, vertical + 1]);
                    if (!TilesAround.Contains(GameControls.PlayedGame.Minefield[horizontal, vertical + 1]))
                        TilesAround.Add(GameControls.PlayedGame.Minefield[horizontal, vertical + 1]);
                }
            }
        }
        public void MinesAroundCalculator()
        {
            foreach (Tile tile in TilesAround)
            {
                if (tile.Mine)
                    MinesAround++;
            }
        }

        public UncoveredTile UncoverTile()
        {
            return new UncoveredTile(this);
        }

        public HighlightedTile HighlightTile()
        {
            return new HighlightedTile(this);
        }
        


        public abstract void PrintTile();
    }
}
