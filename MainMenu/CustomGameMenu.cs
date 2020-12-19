using System;
using System.Collections.Generic;
using System.Text;

namespace GloriousMinesweeper
{
    class CustomGameMenu : GameMenu
    {
        public CustomGameMenu(ConsoleKey keypressed, int chosenLine) : base("Custom", DiffSwitcher.GameMenus[DiffSwitcher.ChosenMenu].Difficulty)
        {
            ChosenLine = chosenLine;
            DiffSwitcher.GameMenus[3] = this;
            DiffSwitcher.SwitchTo(3, false);
            if (keypressed == ConsoleKey.LeftArrow)
                GameSettings[chosenLine].ChangeValue(-1);
            else if (keypressed == ConsoleKey.RightArrow)
                GameSettings[chosenLine].ChangeValue(1);
            

        }

        public override ConsoleKey MenuAction()
        {
            ConsoleKey keypressed;
            do
            {
                GameSettings[ChosenLine].Print(true);
                keypressed = Console.ReadKey(true).Key;
                switch (keypressed)
                {
                    case ConsoleKey.UpArrow:
                        if (ChosenLine == 0)
                        {
                            GameSettings[ChosenLine].Print(false);
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
                            GameSettings[ChosenLine].ChangeValue(-1);

                        break;
                    case ConsoleKey.RightArrow:
                        if (GameSettings[ChosenLine].Colour)
                            foreach (GameMenu menu in DiffSwitcher.GameMenus)
                                if (menu == null)
                                    continue;
                                else
                                    menu.GameSettings[ChosenLine].ChangeValue(1);
                        else
                            GameSettings[ChosenLine].ChangeValue(1);
                        break;
                    case ConsoleKey.Enter:
                        return keypressed;
                }
                GameSettings[ChosenLine].Print(true);
            } while (true);
        }

    }
}
