using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SectionData
    {
        IParticipant Left   { get; set; }
        int DistanceLeft    { get; set; }
        IParticipant Right  { get; set; }
        int DistanceRight   { get; set; }

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
