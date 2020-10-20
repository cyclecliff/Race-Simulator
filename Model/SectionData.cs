using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SectionData
    {
        public IParticipant Left   { get; set; }
        public int DistanceLeft    { get; set; }
        public IParticipant Right  { get; set; }
        public int DistanceRight   { get; set; }

        public SectionData()
        {

        }

        public SectionData(IParticipant left)
        {
            Left  = left;
            DistanceLeft = 0;
        }

        public SectionData(IParticipant left, IParticipant right)
        {
            Left  = left;
            DistanceLeft = 0;
            Right = right;
            DistanceRight = 0;
        }

        public static implicit operator SectionTypes(SectionData v)
        {
            throw new NotImplementedException();
        }
    }
}
