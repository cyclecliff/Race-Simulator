using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Controller
{
    public static class Visualization
    {


        //gunna make each segment 5x5 and each variation
    public static void Initialize()
        {

        }


        public static void writeSection(string[] section)
        {
            foreach(String line in section)
            {
                Console.WriteLine(line);
            }
        }


        #region graphics  //5x5 full variaton write all variations
        private static string[] _FinishH            = { "_____", "# # #", "     ", " # # ",  "_____" };
        private static string[] _FinishV            = { "|#  |", "|  #|", "|#  |", "|  #|",  "|#  |" };
        private static string[] _StartGridH         = { "", "", "", "", "" };
        private static string[] _StartGridV         = { "", "", "", "", "" };
        private static string[] _RightCornerH       = { " ____", "/   _", "|   / ", "|  | ", "|  | " };
        private static string[] _RightCornerV       = _LeftCornerH;
        private static string[] _LeftCornerH        = { "____", "_   \\", " '\'   |", "", "" };
        private static string[] _x       = { "", "", "", "", "" };
        private static string[] _t       = { "", "", "", "", "" };
        private static string[] _j       = { "", "", "", "", "" };
        private static string[] _m       = { "", "", "", "", "" };
        //mapping functie string[] GetSectionStringArray(SectionType ST, Direction) { switch(ST) case 1} zet ook op je baan placeholders neer (1 en 2) zodat je de richting ook meeneemt
        #endregion

    }
}
