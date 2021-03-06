﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GloriousMinesweeper
{
    static class DiffSwitcher
    {
        public static GameMenu[] GameMenus;
        public static int ChosenMenu;
                
        public static void SwitchMenu(ConsoleKey consoleKey)
        {
            if (consoleKey == ConsoleKey.LeftArrow && ChosenMenu != 0)
            {
                ChosenMenu--;
                Console.Clear();
                GameMenus[ChosenMenu].PrintMenu(true);
            }
                
            else if (consoleKey == ConsoleKey.RightArrow)
            {
                ChosenMenu++;
                if (ChosenMenu < GameMenus.Length)
                    if (GameMenus[ChosenMenu] != null)
                    {
                        Console.Clear();
                        GameMenus[ChosenMenu].PrintMenu(true);
                    }
                    else
                        ChosenMenu--;
                else
                    ChosenMenu--;
            }
        }

        public static void SwitchTo(int number, bool highlightName)
        {
            ChosenMenu = number;
            Console.Clear();
            GameMenus[ChosenMenu].PrintMenu(highlightName);
        }

        public static int[] EnableSwitch()
        {
            ConsoleKey keypressed;
            do
            {
                keypressed = Console.ReadKey(true).Key;
                switch (keypressed)
                {
                    case ConsoleKey.LeftArrow:
                        SwitchMenu(keypressed);
                        break;
                    case ConsoleKey.RightArrow:
                        SwitchMenu(keypressed);
                        break;
                    case ConsoleKey.DownArrow:
                        keypressed = GameMenus[ChosenMenu].MenuAction();
                        break;
                }
            } while (keypressed != ConsoleKey.Enter && keypressed != ConsoleKey.Tab);
            if (keypressed == ConsoleKey.Enter)
            {
                int[] parameters = new int[10];
                for (int x = 0; x != 10; x++)
                {
                    parameters[x] = GameMenus[ChosenMenu].GameSettings[x].SettingValue;
                }
                return parameters;
            }
            else
            {
                do
                {
                    keypressed = GameMenus[3].MenuAction();
                } while (keypressed != ConsoleKey.Enter && keypressed != ConsoleKey.UpArrow);
                if (keypressed == ConsoleKey.Enter)
                {
                    int[] parameters = new int[10];
                    for (int x = 0; x != 10; x++)
                    {
                        parameters[x] = GameMenus[ChosenMenu].GameSettings[x].SettingValue;
                    }
                    return parameters;
                }
                else
                {
                    PrintMenuName(true);
                    return EnableSwitch();
                }
            }
        }
        public static void PrintMenuName(bool highlight)
        {
            Console.SetCursorPosition(0, 0);
            if (highlight)
                Console.ForegroundColor = ConsoleColor.Red;
            int leftPadding = (Console.WindowWidth - GameMenus[ChosenMenu].Name.Length) / 2;
            int rightPadding = (Console.WindowWidth - GameMenus[ChosenMenu].Name.Length - leftPadding);
            Console.Write(new string(' ', leftPadding) + GameMenus[ChosenMenu].Name + new string(' ', rightPadding));
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
