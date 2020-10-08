using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Text;

namespace RaceBaan
{
    public static class Visualization
    {

        public static void Initialize()
        {

        }

        public static void DrawSection(string[] section, int x, int y) //add coordinates? //note the x and of every section in a different method to drawy later
        {
            Console.SetCursorPosition(x, y);
            
            foreach(String line in section)
            {
                Console.Write(line);
            }
        }

        /*
                  * 1. find out how much the track "sticks out" this will give you an x and y value
                  * 2. give each section coordinates with the previous values in mind
                  * 3. print the sections in a method which uses just the coordinates of the sections themselves to write them down
                  * 
                  * 1.METHOD THAT SETS THE DIRECTIONS
                  * 2.METHOD THAT FINDS THE OFFSET
                  * 3.METHOD THAT SETS THE COORDINATES USING THE OFFSET
                  * 4.METHOD THAT DRAWS THE SECTIONS USING THE DATA MENTIONED ABOVE
                  * 5.METHOD THAT ENCAPSULATES THE PREVIOUS 4
                  * 
                  */

        public static void setDirections(Track track, Direction _startingdirection)
        {
            Direction direction = _startingdirection;        
           
            foreach (Section section in track.Sections)

            {
                section.Direction = direction;

                switch (section.SectionType)
                {
                    case SectionTypes.Straight      :     
                    case SectionTypes.StartGrid     :
                    case SectionTypes.Finish        :
                        if (direction == Direction.Up)      {  direction = Direction.Up;             }
                        if (direction == Direction.Right)   {  direction = Direction.Right;          }
                        if (direction == Direction.Down)    {  direction = Direction.Down;           }
                        if (direction == Direction.Left)    {  direction = Direction.Left;           }
                        break;
                    case SectionTypes.LeftCorner    :
                        if (direction == Direction.Up)      {  direction = Direction.Left;   break;  }
                        if (direction == Direction.Right)   {  direction = Direction.Up;     break;  }
                        if (direction == Direction.Down)    {  direction = Direction.Right;  break;  }   
                        if (direction == Direction.Left)    {  direction = Direction.Down;   break;  }
                        break;
                    case SectionTypes.RightCorner   :
                        if (direction == Direction.Up)      {  direction = Direction.Right;  break;  }
                        if (direction == Direction.Right)   {  direction = Direction.Down;   break;  }
                        if (direction == Direction.Down)    {  direction = Direction.Left;   break;  }
                        if (direction == Direction.Left)    {  direction = Direction.Up;     break;  }
                        break;
                }
                 //Direction of each section is now stored in each individual Section-object
            }
        }

        public static void findOffsetXandY()
        {

        }

        public static void setCoordinatesOfEachSection(Track track)
        {
            track.StartXoffset = track.StartXoffset * -1;
            track.StartYoffset = track.StartYoffset * -1;




        }

        public static void DrawTrack(Track track)
        { 
            // mapping functie string[] GetSectionStringArray(SectionType ST, Direction) { switch(ST) case 1} 

            foreach (Section section in track.Sections)
            {
                switch (section.SectionType)
                {
                    case SectionTypes.Straight      :
                        if (section.Direction == Direction.Up)      { DrawSection(_Straight_Vertical_0, section.X, section.Y);         } //?
                        if (section.Direction == Direction.Right)   { DrawSection(_Straight_Horizontal_1, section.X, section.Y);       }
                        if (section.Direction == Direction.Down)    { DrawSection(_Straight_Vertical_2, section.X, section.Y);         }
                        if (section.Direction == Direction.Left)    { DrawSection(_Straight_Horizontal_3, section.X, section.Y);       }
                    break;

                    case SectionTypes.LeftCorner    :
                        if (section.Direction == Direction.Up)      { DrawSection(_LeftCorner_Vertical_0, section.X, section.Y);       break; }
                        if (section.Direction == Direction.Right)   { DrawSection(_LeftCorner_Horizontal_1, section.X, section.Y);     break; }
                        if (section.Direction == Direction.Down)    { DrawSection(_LeftCorner_Vertical_2, section.X, section.Y);       break; }
                        if (section.Direction == Direction.Left)    { DrawSection(_LeftCorner_Horizontal_3, section.X, section.Y);     break; }
                        break;

                    case SectionTypes.RightCorner   :
                        if (section.Direction == Direction.Up)      { DrawSection(_RightCorner_Vertical_0, section.X, section.Y);      break; }
                        if (section.Direction == Direction.Right)   { DrawSection(_RightCorner_Horizontal_1, section.X, section.Y);    break; }
                        if (section.Direction == Direction.Down)    { DrawSection(_RightCorner_Vertical_2, section.X, section.Y);      break; }
                        if (section.Direction == Direction.Left)    { DrawSection(_RightCorner_Horizontal_3, section.X, section.Y);    break; }
                        break;

                    case SectionTypes.StartGrid     :
                        if (section.Direction == Direction.Up)      { DrawSection(_Start_Vertical_0, section.X, section.Y);            }
                        if (section.Direction == Direction.Right)   { DrawSection(_Start_Horizontal_1, section.X, section.Y);          }
                        if (section.Direction == Direction.Down)    { DrawSection(_Start_Vertical_2, section.X, section.Y);            }
                        if (section.Direction == Direction.Left)    { DrawSection(_Start_Horizontal_3, section.X, section.Y);          }
                        break;

                    case SectionTypes.Finish        :
                        if (section.Direction == Direction.Up)      { DrawSection(_Finish_Vertical_0, section.X, section.Y);           }
                        if (section.Direction == Direction.Right)   { DrawSection(_Finish_Horizontal_1, section.X, section.Y);         }
                        if (section.Direction == Direction.Down)    { DrawSection(_Finish_Vertical_2, section.X, section.Y);           }
                        if (section.Direction == Direction.Left)    { DrawSection(_Finish_Horizontal_3, section.X, section.Y);         }
                        break;
                }
            }
        }
        #region graphics  //5x5 full variaton write all variations
        private static string[] _Finish_Horizontal_1        = { "-----", 
                                                                "#1# #", 
                                                                " # # ", 
                                                                "#2# #", 
                                                                "-----" };
        private static string[] _Finish_Horizontal_3        = { "-----", 
                                                                "# #2#", 
                                                                " # # ", 
                                                                "# #1#", 
                                                                "-----" };
        private static string[] _Finish_Vertical_0          = { "|# #|", 
                                                                "| # |", 
                                                                "|# #|", 
                                                                "|1#2|", 
                                                                "|# #|" };
        private static string[] _Finish_Vertical_2          = { "|# #|", 
                                                                "|2#1|", 
                                                                "|# #|", 
                                                                "| # |", 
                                                                "|# #|" }; // check
        
        private static string[] _Start_Horizontal_1         = { "-----", 
                                                                "1>   ", 
                                                                "     ", 
                                                                "  2> ", 
                                                                "-----" };
        private static string[] _Start_Horizontal_3         = { "-----", 
                                                                " <2  ", 
                                                                "     ", 
                                                                "   <1", 
                                                                "-----" };
        private static string[] _Start_Vertical_0           = { "|   |", 
                                                                "|  ^|", 
                                                                "|  2|", 
                                                                "|^  |", 
                                                                "|1  |" };
        private static string[] _Start_Vertical_2           = { "|  1|", 
                                                                "|  v|", 
                                                                "|2  |", 
                                                                "|v  |", 
                                                                "|   |" }; // check

        private static string[] _RightCorner_Horizontal_1   = { "---\\ ", 
                                                                "1   |", 
                                                                "    |", 
                                                                "2   |", 
                                                                "\\   |" };
        private static string[] _RightCorner_Horizontal_3   = { "|   \\", 
                                                                "|   2", 
                                                                "|    ", 
                                                                "|   1", 
                                                                " \\---" };
        private static string[] _RightCorner_Vertical_0     = { " ----", 
                                                                "/    ", 
                                                                "|    ", 
                                                                "|    ", 
                                                                "|1 2/" };
        private static string[] _RightCorner_Vertical_2     = { "/2 1|", 
                                                                "    |", 
                                                                "    |", 
                                                                "    /", 
                                                                "---- " };//check

        private static string[] _LeftCorner_Horizontal_1    = { "/   |", 
                                                                "1   |",        
                                                                "    |", 
                                                                "2   |", 
                                                                "---/" };
        private static string[] _LeftCorner_Horizontal_3    = { " /---", 
                                                                "|   2", 
                                                                "|    ", 
                                                                "|   1", 
                                                                "|   /" };
        private static string[] _LeftCorner_Vertical_0      = { "---- ", 
                                                                "    \\",
                                                                "    |", 
                                                                "    |", 
                                                                "\\1 2|" };
        private static string[] _LeftCorner_Vertical_2      = { "|2 1\\", 
                                                                "|    ", 
                                                                "|    ", 
                                                                "\\    ", 
                                                                " ----" }; 




        private static string[] _Straight_Horizontal_1      = { "-----", 
                                                                "1    ", 
                                                                "  -  ",
                                                                "2    ",
                                                                "-----" };
        private static string[] _Straight_Horizontal_3      = { "-----", 
                                                                "    2", 
                                                                "  -  ", 
                                                                "    1", 
                                                                "-----" };
        private static string[] _Straight_Vertical_0        = { "|   |", 
                                                                "|   |", 
                                                                "| | |", 
                                                                "|   |", 
                                                                "|1 2|" };
        private static string[] _Straight_Vertical_2        = { "|2 1|", 
                                                                "|   |", 
                                                                "| | |", 
                                                                "|   |", 
                                                                "|   |" };
        #endregion
    }
}
