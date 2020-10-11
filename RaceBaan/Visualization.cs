﻿using Model;
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

        public static void DrawSection(Section section) //add coordinates? //note the x and of every section in a different method to drawy later
        {
            //we have the coordinates, and the direction, and the type

            string[] wegstuk = new string[5];

            switch (section.SectionType)
            {
                case SectionTypes.Straight                      :   
                    if (section.Direction == Direction.Up)      { wegstuk = _Straight_Vertical_0;  }
                    if (section.Direction == Direction.Right)   { wegstuk = _Straight_Horizontal_1; }
                    if (section.Direction == Direction.Down)    { wegstuk = _Straight_Vertical_2; }
                    if (section.Direction == Direction.Left)    { wegstuk = _Straight_Horizontal_3; }
                    break;
                case SectionTypes.StartGrid                     :
                    if (section.Direction == Direction.Up)      { wegstuk = _Start_Vertical_0; }
                    if (section.Direction == Direction.Right)   { wegstuk = _Start_Horizontal_1; }
                    if (section.Direction == Direction.Down)    { wegstuk = _Start_Vertical_2; }
                    if (section.Direction == Direction.Left)    { wegstuk = _Start_Horizontal_3; }
                    break;
                case SectionTypes.Finish                        :
                    if (section.Direction == Direction.Up)      { wegstuk = _Finish_Vertical_0; }
                    if (section.Direction == Direction.Right)   { wegstuk = _Finish_Horizontal_1; }
                    if (section.Direction == Direction.Down)    { wegstuk = _Finish_Vertical_2; }
                    if (section.Direction == Direction.Left)    { wegstuk = _Finish_Horizontal_3; }
                    break;
                case SectionTypes.LeftCorner                    :
                    if (section.Direction == Direction.Up)      { wegstuk = _LeftCorner_Vertical_0; }
                    if (section.Direction == Direction.Right)   { wegstuk = _LeftCorner_Horizontal_1; }
                    if (section.Direction == Direction.Down)    { wegstuk = _LeftCorner_Vertical_2; }
                    if (section.Direction == Direction.Left)    { wegstuk = _LeftCorner_Horizontal_3; }
                    break;
                case SectionTypes.RightCorner                   :
                    if (section.Direction == Direction.Up)      { wegstuk = _RightCorner_Vertical_0; }
                    if (section.Direction == Direction.Right)   { wegstuk = _RightCorner_Horizontal_1; }
                    if (section.Direction == Direction.Down)    { wegstuk = _RightCorner_Vertical_2; }
                    if (section.Direction == Direction.Left)    { wegstuk = _RightCorner_Horizontal_3; }
                    break;
            }

            foreach(String line in wegstuk)
            {
                Console.SetCursorPosition(section.X, section.Y);                        //gaat iets mis bij het plaatsen van de coordinaten`, hij word negatief terwijl dat niet zou moeten kunnen
                Console.Write(line);
                section.Y += 1;
            }
            section.Y -= 5;
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
        */

        public static void setDirections(Track track, Direction _startingdirection)
        {
            Direction direction = _startingdirection;        
           
            foreach (Section section in track.Sections)
            {
                section.Direction = direction;

                switch (section.SectionType)
                {
                    case SectionTypes.Straight              :     
                    case SectionTypes.StartGrid             :
                    case SectionTypes.Finish                :
                        if (direction == Direction.Up)      {  direction = Direction.Up;             }
                        if (direction == Direction.Right)   {  direction = Direction.Right;          }
                        if (direction == Direction.Down)    {  direction = Direction.Down;           }
                        if (direction == Direction.Left)    {  direction = Direction.Left;           }
                        break;
                    case SectionTypes.LeftCorner            :
                        if (direction == Direction.Up)      {  direction = Direction.Left;   break;  }
                        if (direction == Direction.Right)   {  direction = Direction.Up;     break;  }
                        if (direction == Direction.Down)    {  direction = Direction.Right;  break;  }   
                        if (direction == Direction.Left)    {  direction = Direction.Down;   break;  }
                        break;
                    case SectionTypes.RightCorner           :
                        if (direction == Direction.Up)      {  direction = Direction.Right;  break;  }
                        if (direction == Direction.Right)   {  direction = Direction.Down;   break;  }
                        if (direction == Direction.Down)    {  direction = Direction.Left;   break;  }
                        if (direction == Direction.Left)    {  direction = Direction.Up;     break;  }
                        break;
                }
                 //Direction of each section is now stored in each individual Section-object
            }
        }
        
        public static void findOffsetXandY(Track track)
        {
            int xoffset = 0;
            int yoffset = 0;

            int xtrueoffset = 0;
            int ytrueoffset = 0;

            foreach (Section section in track.Sections)
            {
                
                switch (section.SectionType)
                { //ytrueoffset = yoffset; xtrueoffset = xtrueoffset;
                    case SectionTypes.Straight:
                    case SectionTypes.StartGrid:
                    case SectionTypes.Finish:
                        if (section.Direction == Direction.Up)      {  yoffset -= 5; } //first one should always be 0,0, how do we accomplish that
                        if (section.Direction == Direction.Right)   {  xoffset += 5; }
                        if (section.Direction == Direction.Down)    {  yoffset += 5; }
                        if (section.Direction == Direction.Left)    {  xoffset -= 5; }
                        break;
                    case SectionTypes.LeftCorner:
                        if (section.Direction == Direction.Up)      {  yoffset -= 5; xoffset -= 5; }
                        if (section.Direction == Direction.Right)   {  yoffset -= 5; xoffset += 5; }
                        if (section.Direction == Direction.Down)    {  yoffset += 5; xoffset += 5; }
                        if (section.Direction == Direction.Left)    {  yoffset += 5; xoffset -= 5; }
                        break;
                    case SectionTypes.RightCorner:
                        if (section.Direction == Direction.Up)      {  yoffset -= 5; xoffset += 5; }
                        if (section.Direction == Direction.Right)   {  yoffset += 5; xoffset += 5; }
                        if (section.Direction == Direction.Down)    {  yoffset += 5; xoffset -= 5; }
                        if (section.Direction == Direction.Left)    {  yoffset -= 5; xoffset -= 5; }
                        break;
                }

                if(xoffset < xtrueoffset) { xtrueoffset = xoffset; } //sets the most amount the track sticks out so it wont become 0 when the track goes back
                if(yoffset < ytrueoffset) { ytrueoffset = yoffset; }
                //the total x and y offset is now stored in the track object
            }

            //xtrueoffset += 5;
            //ytrueoffset += 5;

            track.StartXoffset = xtrueoffset;
            track.StartYoffset = ytrueoffset;
        }

        public static void setCoordinatesOfEachSection(Track track)
        {
            track.StartXoffset = track.StartXoffset * -1;
            track.StartYoffset = track.StartYoffset * -1;

            int currentX = 0;
            int currentY = 0;

            currentX += track.StartXoffset;
            currentY += track.StartYoffset;


            // UP    = + 5 Y
            // RIGHT = perfect
            // DOWN  = + 5 X
            // LEFT  = + 5 Y / + 5 X

            foreach (Section section in track.Sections)
            {
                switch (section.SectionType)
                {
                    case SectionTypes.Straight:
                    case SectionTypes.StartGrid: //a right corner changes 2 coordinates!
                    case SectionTypes.Finish:
                        if (section.Direction == Direction.Up)      { section.Y = currentY; section.X = currentX; currentY -= 5; }
                        if (section.Direction == Direction.Right)   { section.X = currentX; section.Y = currentY; currentX += 5; }
                        if (section.Direction == Direction.Down)    { section.Y = currentY; section.X = currentX; currentY += 5; }
                        if (section.Direction == Direction.Left)    { section.X = currentX; section.Y = currentY; currentX -= 5; }
                        break;
                    case SectionTypes.LeftCorner:
                        if (section.Direction == Direction.Up)      { section.Y = currentY; section.X = currentX; currentX -= 5; } //fix directions
                        if (section.Direction == Direction.Right)   { section.X = currentX; section.Y = currentY; currentY -= 5; }
                        if (section.Direction == Direction.Down)    { section.Y = currentY; section.X = currentX; currentX += 5; }
                        if (section.Direction == Direction.Left)    { section.X = currentX; section.Y = currentY; currentY += 5; }
                        break;
                    case SectionTypes.RightCorner:
                        if (section.Direction == Direction.Up)      { section.Y = currentY; section.X = currentX; currentX += 5; }
                        if (section.Direction == Direction.Right)   { section.X = currentX; section.Y = currentY; currentY += 5; }
                        if (section.Direction == Direction.Down)    { section.Y = currentY; section.X = currentX; currentX -= 5; }
                        if (section.Direction == Direction.Left)    { section.X = currentX; section.Y = currentY; currentY -= 5; }
                        break;
                }
            }
        }


        public static void DrawTrack(Track track, Direction startingdirection)
        {
            // mapping functie string[] GetSectionStringArray(SectionType ST, Direction) { switch(ST) case 1} 
            setDirections(track, startingdirection); //seems to be doing its job
            findOffsetXandY(track);                //5 off
            setCoordinatesOfEachSection(track);
            foreach (Section section in track.Sections)
            {
                DrawSection(section);
                #region
                /*
                switch (section.SectionType)
                {
                    case SectionTypes.Straight      :
                        if (section.Direction == Direction.Up)      { DrawSection(section);         } //?
                        if (section.Direction == Direction.Right)   { DrawSection(_Straight_Horizontal_1);       }
                        if (section.Direction == Direction.Down)    { DrawSection(_Straight_Vertical_2);         }
                        if (section.Direction == Direction.Left)    { DrawSection(_Straight_Horizontal_3);       }
                    break;

                    case SectionTypes.LeftCorner    :
                        if (section.Direction == Direction.Up)      { DrawSection(_LeftCorner_Vertical_0);       break; }
                        if (section.Direction == Direction.Right)   { DrawSection(_LeftCorner_Horizontal_1);     break; }
                        if (section.Direction == Direction.Down)    { DrawSection(_LeftCorner_Vertical_2);       break; }
                        if (section.Direction == Direction.Left)    { DrawSection(_LeftCorner_Horizontal_3);     break; }
                        break;

                    case SectionTypes.RightCorner   :
                        if (section.Direction == Direction.Up)      { DrawSection(_RightCorner_Vertical_0);      break; }
                        if (section.Direction == Direction.Right)   { DrawSection(_RightCorner_Horizontal_1);    break; }
                        if (section.Direction == Direction.Down)    { DrawSection(_RightCorner_Vertical_2);      break; }
                        if (section.Direction == Direction.Left)    { DrawSection(_RightCorner_Horizontal_3);    break; }
                        break;

                    case SectionTypes.StartGrid     :
                        if (section.Direction == Direction.Up)      { DrawSection(_Start_Vertical_0);            }
                        if (section.Direction == Direction.Right)   { DrawSection(_Start_Horizontal_1);          }
                        if (section.Direction == Direction.Down)    { DrawSection(_Start_Vertical_2);            }
                        if (section.Direction == Direction.Left)    { DrawSection(_Start_Horizontal_3);          }
                        break;

                    case SectionTypes.Finish        :
                        if (section.Direction == Direction.Up)      { DrawSection(_Finish_Vertical_0);           }
                        if (section.Direction == Direction.Right)   { DrawSection(_Finish_Horizontal_1);         }
                        if (section.Direction == Direction.Down)    { DrawSection(_Finish_Vertical_2);           }
                        if (section.Direction == Direction.Left)    { DrawSection(_Finish_Horizontal_3);         }
                        break;
                }
                */
                #endregion
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
