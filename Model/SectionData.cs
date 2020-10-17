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
        }

        public SectionData(IParticipant left, IParticipant right)
        {
            Left  = left;
            Right = right;
        }

        public static implicit operator SectionTypes(SectionData v)
        {
            throw new NotImplementedException();
        }
    }
}
