using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Section
    {
        public int X { get; set; }
        public int Y { get; set; }
        //voeg x, y en direction toe voor makkelijk gebruik in je berekeningen
        public Direction Direction { get; set; }

        public SectionTypes SectionType { get; set;  }

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
