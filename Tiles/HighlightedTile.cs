using System;
using System.Collections.Generic;
using System.Text;

namespace GloriousMinesweeper
{
    class HighlightedTile : Tile
    {
        public ConsoleColor OriginalColor { get; }

        public HighlightedTile(Tile originalTile)
        {
            MinesAround = originalTile.MinesAround;
            Covered = originalTile.Covered;
            Flag = originalTile.Flag;
            Mine = originalTile.Mine;
            Color = GameControls.PlayedGame.Highlight;
            OriginalColor = originalTile.Color;
            TilesAround = originalTile.TilesAround;
            Position = originalTile.Position;
            MinefieldPositon = originalTile.MinefieldPositon;
        }
        public void FlagTile()
        {
            if (Flag)
                Flag = false;
            else
                Flag = true;
        }



        public override void PrintTile()
        {
            Position.GoTo();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = Color;
            if (Covered)
                Console.Write("  ");
            else
            {
                Console.Write(' ');
                Console.Write(MinesAround);
            }
        }

        public void Uncover()
        {
            if (Covered && !Flag)
            {
                if (Mine)
                    GameControls.GameLose();
                else
                {
                    GameControls.PlayedGame.Minefield[MinefieldPositon.Horizontal, MinefieldPositon.Vertical] = UncoverTile();
                    foreach (Tile tile in TilesAround)
                        if (tile.Covered)
                            GameControls.PlayedGame.Minefield[tile.MinefieldPositon.Horizontal, tile.MinefieldPositon.Vertical] = tile.UncoverTile();
                    
                }
            }
        }
    }
}
