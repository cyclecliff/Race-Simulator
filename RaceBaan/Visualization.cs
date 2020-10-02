using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace RaceBaan
{
    public static class Visualization
    {

        public static void Initialize()
        {

        }


        public static void writeSection(string[] section)
        {
            foreach (String line in section)
            {
                Console.WriteLine(line);
            }
        }
        public static void DrawSection(string[] section)
        {
            foreach(String line in section)
            {
                Console.WriteLine(line);
            }
        }
        public static void DrawTrack(Track track)
        {

            int richting = 0; // 0 = North , 1 = East , 2 = South , 3 = West   [0,1,2,3]


            // mapping functie string[] GetSectionStringArray(SectionType ST, Direction) { switch(ST) case 1} 
            // cursor.setPosition
            // na iedere bocht een richting index aanpassen.

            foreach (Section section in track.Sections)
            {
                switch (section.SectionType)
                {
                    case SectionTypes.Straight:
                        DrawSection(_Straight_Horizontal);
                        break;

                    case SectionTypes.LeftCorner    :
                        DrawSection(_LeftCorner_Horizontal);
                        break;

                    case SectionTypes.RightCorner   :
                        DrawSection(_RightCorner_Horizontal);
                        break;

                    case SectionTypes.StartGrid     :
                        DrawSection(_Start_Horizontal);
                        break;

                    case SectionTypes.Finish        :
                        DrawSection(_Finish_Horizontal);
                        break;
                }
            }
        }
        #region graphics  //5x5 full variaton write all variations
        private static string[] _Finish_Horizontal      = { "-----", "#1# #", " # # ", "#2# #", "-----" };
        private static string[] _Finish_Vertical        = { "|# #|", "| # |", "|# #|", "|1#2|", "|# #|" };

        private static string[] _Start_Horizontal      = { "-----", "1>   ", "     ", "  2> ", "-----" };
        private static string[] _Start_Vertical         = { "|   |", "|  ^|", "|  2|", "|^  |", "|1  |" };

        private static string[] _RightCorner_Horizontal = { "---- ", "1   \\", "    |", "2   |", "\\   |" };
        private static string[] _RightCorner_Vertical   = { " ----", "/    ", "|    ", "|    ", "|1 2/" };

        private static string[] _LeftCorner_Horizontal  = { "/   |", "1   |", "    |", "2   /", "---- " };
        private static string[] _LeftCorner_Vertical    = { "---- ", "   \\", "    |", "    |", "\\   |" }; //= RightCorner_Horizontal

        private static string[] _Straight_Horizontal    = { "-----", "1    ", "     ", "2    ", "-----" };
        private static string[] _Straight_Vertical      = { "|   |", "|   |", "|   |", "|   |", "|   |" };
        #endregion

    }
}
