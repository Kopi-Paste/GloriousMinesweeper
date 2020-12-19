using System;

namespace GloriousMinesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
                
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            

            GameMenu easy = new GameMenu("Easy", Difficulties.Easy);
            GameMenu medium = new GameMenu("Medium", Difficulties.Medium);
            GameMenu hard = new GameMenu("Hard", Difficulties.Hard);
            DiffSwitcher.GameMenus = new GameMenu[4];
            DiffSwitcher.GameMenus[0] = easy;
            DiffSwitcher.GameMenus[1] = medium;
            DiffSwitcher.GameMenus[2] = hard;
            DiffSwitcher.GameMenus[3] = null;
            DiffSwitcher.ChosenMenu = 0;

            DiffSwitcher.SwitchTo(0, true);
            
            int[] gameParameteres = DiffSwitcher.EnableSwitch();
            Console.Clear();
            Console.WriteLine(new string(' ', (Console.WindowWidth - 10) / 2) + "Loading..." + new string(' ', (Console.WindowWidth - 10) / 2));
            GameControls.PlayedGame = new Game(gameParameteres);
            GameControls.PlayedGame.TilesAndMinesCalculator();
            Console.Clear();

            foreach (Tile tile in GameControls.PlayedGame.Minefield)
                tile.PrintTile();
        }
    }
}
