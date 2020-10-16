using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Section
    {
        public int X;

        public int Y;
        //voeg x, y en direction toe voor makkelijk gebruik in je berekeningen

        public SectionTypes SectionType { get; set;  }

        public Direction Direction { get; set; }

        public Section(SectionTypes sectionType)
        {
            SectionType = sectionType;
        }
    }

    public enum Direction
    {
        Up,
        Right,
        Down,
        Left,
    }
}
