using System;
using System.Collections.Generic;
using System.Text;

namespace GloriousMinesweeper
{
    class Coordinates
    {
        public int Horizontal { get; private set; }
        public int Vertical { get; private set; }

        public Coordinates(int horizontal, int vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
        }

        public void GoTo()
        {
            Console.SetCursorPosition(Horizontal, Vertical);
        }
    }
}
