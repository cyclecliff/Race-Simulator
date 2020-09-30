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


        #region graphics  //5x5 full variaton
        private static string[] _FinishH            = { "_____", "# # #", "     ", " # # ",  "_____" };
        private static string[] _FinishV            = { "|#  |", "|  #|", "|#  |", "|  #|",  "|#  |" };
        private static string[] _StartGridH         = { "", "", "", "", "" };
        private static string[] _StartGridV         = { "", "", "", "", "" };
        private static string[] _RightCornerH       = { " ____", "/   _", "|   / ", "|  | ", "|  | " };
        private static string[] _RightCornerV       = _LeftCornerH;
        private static string[] _LeftCornerH        = { "____", "_   '\'", " '\'   |", "", "" };
        private static string[] _x       = { "", "", "", "", "" };
        private static string[] _t       = { "", "", "", "", "" };
        private static string[] _j       = { "", "", "", "", "" };
        private static string[] _m       = { "", "", "", "", "" };

        #endregion

    }
}
