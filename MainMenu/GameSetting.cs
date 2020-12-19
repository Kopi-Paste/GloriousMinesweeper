using System;
using System.Collections.Generic;
using System.Text;

namespace GloriousMinesweeper
{
    class GameSetting
    {
        private int settingValue;
        private bool colour;


        private string Setting { get; }
        public int SettingValue
        {
            get
            {
                return settingValue;
            }
            private set
            {
                settingValue = value;
            }
        }
        public bool Colour
        {
            get
            {
                return colour;
            }
            private set
            {
                colour = value;
            }
        }

        private Coordinates StartPosition { get; }



        public GameSetting(string text, int defaultValue, bool colourable, int line)
        {
            Setting = text;
            SettingValue = defaultValue;
            Colour = colourable;
            StartPosition = new Coordinates(0, line);
        }


        public void ChangeValue(int change)
        {
            SettingValue += change;
            Print(true);
        }

        public void Print(bool highlight)
        {
            StartPosition.GoTo();
            if (highlight)
                Console.ForegroundColor = ConsoleColor.Red;
            string toPrint = "";
            if (Colour)
                toPrint = $"{Setting}: {(ConsoleColor)SettingValue}";
            else
                toPrint = $"{Setting}: {SettingValue}";

            int leftPadding = (Console.WindowWidth - toPrint.Length) / 2;
            int rightPadding = Console.WindowWidth - toPrint.Length - leftPadding;
            Console.Write(new string(' ', leftPadding) + toPrint + new string(' ', rightPadding));

            Console.ForegroundColor = ConsoleColor.White;
        }


    }
}
