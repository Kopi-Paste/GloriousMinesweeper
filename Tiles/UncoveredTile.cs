﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GloriousMinesweeper
{
    class UncoveredTile : Tile
    {
        public UncoveredTile(Tile originalTile)
        {
            MinesAround = originalTile.MinesAround;
            Covered = false;
            Flag = false;
            Mine = originalTile.Mine;
            if (originalTile.Color == GameControls.PlayedGame.Cover)
                Color = GameControls.PlayedGame.Uncover;
            else if (originalTile.Color == GameControls.PlayedGame.CoverSecondary)
                Color = GameControls.PlayedGame.UncoverSecondary;
            TilesAround = originalTile.TilesAround;
            Position = originalTile.Position;
            MinefieldPositon = originalTile.MinefieldPositon;
        }

        public override void PrintTile()
        {
            Position.GoTo();
            Console.BackgroundColor = Color;
            Console.ForegroundColor = GameControls.PlayedGame.Text;
            Console.Write(' ');
            if (MinesAround != 0)
                Console.Write(MinesAround);
            else
                Console.Write(' ');
        }

    }
}
