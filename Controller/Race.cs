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
        
        //   Dictionairy<Section, SectionData>
        //   <
        //    (Object) Section     [X, Y, Type, Direction] // 
        //    (Object) SectionData [IP Left, DistanceLeft, IP Right, DistanceRight] 
        //   >

        //GetSectionData gives you the sectionData for a given section
        public SectionData GetSectionData(Section section)
        {
            SectionData value;

            if (_positions.TryGetValue(section, out value)) //get the sectiondata object if it exists
            {
                return value;

            } else
            {
                _positions[section] = new SectionData(); // if it doesnt, create a new data object

                return value;
            }
            
        } 

        public Race(Track _track, List<IParticipant> _participants)
        {
            track           = _track;
            Participants    = _participants;
            _random         = new Random(DateTime.Now.Millisecond);
        }              

        public void giveStartPositions(Track track, List<IParticipant> participants)
        {
            foreach (Section section in track.Sections) 
            {
                Console.WriteLine(GetSectionData(section)); 
            }
            /*
             * 
             * 
             */
        }

        public void RandomizeEquipment(List<IParticipant> _participants)     
        {
            foreach(IParticipant participant in _participants)
            {
                participant.Equipment.Quality       = _random.Next();
                participant.Equipment.Performance   = _random.Next();
            }   
        }

    }
}
