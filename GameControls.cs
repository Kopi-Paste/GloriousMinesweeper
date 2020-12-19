using System;
using System.Collections.Generic;
using System.Text;

namespace GloriousMinesweeper
{
    static class GameControls
    {
        private static int horizontalPosition;
        private static int verticalPosition;

        public static Game PlayedGame { get; set; }
        public static int HorizontalPosition
        {
            get
            {
                return horizontalPosition;
            }
            private set
            {
                horizontalPosition = value;
            }
        }
        public static int VerticalPosition
        {
            get
            {
                return verticalPosition;
            }
            private set
            {
                verticalPosition = value;
            }
        }


        public static void GameWin()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = PlayedGame.Text;
            Console.Clear();
            Console.WriteLine("Congratulations, you swept the mines!");
        }
        public static void GameLose()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = PlayedGame.Text;
            Console.Clear();
            Console.WriteLine("Mines are victorious.");
        }

    }
}
