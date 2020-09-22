using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class Race
    {
        public  Track track;
        public  List<IParticipant> Participants;
        public  DateTime StartTime;
        private Random _random;
        private Dictionary<Section, SectionData> _positions;

        public SectionData GetSectionData(Section section)
        { //als op section plek geen value
            SectionData _sectiondata = _positions[section];

            return _sectiondata;
        }
    }
}
