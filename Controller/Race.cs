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
        {
            SectionData value;

            if (_positions.TryGetValue(section, out value))
            {
                return value;

            } else
            {
                _positions[section] = new SectionData();

                return value;
            }
            
        }

        public Race(Track _track, List<IParticipant> _participants)
        {
            track           = _track;
            Participants    = _participants;
            _random         = new Random(DateTime.Now.Millisecond);
        }              

        public void RandomizeEquipment(List<IParticipant> _participants)     
        {
            foreach(IParticipant participant in _participants)
            {
                participant.Equipment = _random;
            }   
        }

    }
}
