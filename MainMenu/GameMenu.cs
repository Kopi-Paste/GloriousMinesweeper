using System;
using System.Collections.Generic;
using System.Text;

namespace GloriousMinesweeper
{
    class GameMenu
    {
        private GameSetting[] gameSettings;
        private List<int> takenColours;



        public string Name { get; }
        public GameSetting[] GameSettings
        {
            get
            {
                return gameSettings;
            }
            private set
            {
                gameSettings = value;
            }
        }
        public List<int> TakenColours
        {
            get
            {
                return takenColours;
            }
            private set
            {
                takenColours = value;
            }
        }
        public int ChosenLine { get; set; }

        public Difficulties Difficulty { get; }



        public GameMenu(string name, Difficulties difficulty)
        {

            Difficulty = difficulty;
            Name = name;
            int mines = 5 * (int)Math.Pow((int)difficulty, 2) * ((int)difficulty + 2);


            GameSettings = new GameSetting[10];
            TakenColours = new List<int>();
            GameSettings[0] = new GameSetting("Number of horizontal tiles", (int)difficulty * 10, false, 7);
            GameSettings[1] = new GameSetting("Number of vertical tiles", (int)difficulty * 10, false, 9);
            GameSettings[2] = new GameSetting("Number of mines", mines, false, 11);
            GameSettings[3] = new GameSetting("Covered tiles colour", 1, true, 13);
            GameSettings[4] = new GameSetting("Covered tiles secondary colour", 2, true, 15);
            GameSettings[5] = new GameSetting("Uncovered tiles colour", 3, true, 17);
            GameSettings[6] = new GameSetting("Uncovered tiles secondary colour", 4, true, 19);
            GameSettings[7] = new GameSetting("Flag colour", 5, true, 21);
            GameSettings[8] = new GameSetting("Highlighted tile colour", 6, true, 23);
            GameSettings[9] = new GameSetting("Text colour", 7, true, 25);
            foreach (GameSetting setting in GameSettings)
            {
                if (setting.Colour)
                    TakenColours.Add(setting.SettingValue);
            }
            ChosenLine = 0;
        }

        public void PrintMenu(bool higlightName)
        {
            DiffSwitcher.PrintMenuName(higlightName);

            Console.WriteLine("Game settings:");
            Console.WriteLine("Use arrow keys");
            foreach (GameSetting setting in GameSettings)
                setting.Print(false);
        }

        public virtual ConsoleKey MenuAction()
        {
            ConsoleKey keypressed;
            do
            {
                DiffSwitcher.PrintMenuName(false);
                GameSettings[ChosenLine].Print(true);
                keypressed = Console.ReadKey(true).Key;
                switch (keypressed)
                {
                    case ConsoleKey.UpArrow:
                        if (ChosenLine == 0)
                        {
                            GameSettings[ChosenLine].Print(false);
                            DiffSwitcher.PrintMenuName(true);
                            return keypressed;
                        }
                        else
                        {
                            GameSettings[ChosenLine].Print(false);
                            ChosenLine--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (ChosenLine != 9)
                        {
                            GameSettings[ChosenLine].Print(false);
                            ChosenLine++;
                        }
                            
                        break;
                    case ConsoleKey.LeftArrow:
                        if (GameSettings[ChosenLine].Colour)
                            foreach (GameMenu menu in DiffSwitcher.GameMenus)
                                if (menu == null)
                                    continue;
                                else
                                    menu.GameSettings[ChosenLine].ChangeValue(-1);
                        else
                        {
                            DiffSwitcher.GameMenus[3] = new CustomGameMenu(keypressed, ChosenLine);
                            return ConsoleKey.Tab;
                        }
                            
                        break;
                    case ConsoleKey.RightArrow:
                        if (GameSettings[ChosenLine].Colour)
                            foreach (GameMenu menu in DiffSwitcher.GameMenus)
                                if (menu == null)
                                    continue;
                                else
                                    menu.GameSettings[ChosenLine].ChangeValue(1);
                        else
                        {
                            DiffSwitcher.GameMenus[3] = new CustomGameMenu(keypressed, ChosenLine);
                            return ConsoleKey.Tab;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return keypressed;
                }
                GameSettings[ChosenLine].Print(true);
                
            } while (true);
        }
    }
    public enum Difficulties
    {
        Easy = 1,
        Medium = 2,
        Hard = 3
    }
}
       
