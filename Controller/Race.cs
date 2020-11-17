using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Timers;

namespace Controller
{
    public class Race
    {
        public  Track track;
        public  List<IParticipant> Participants;
        public  DateTime StartTime;
        private Random _random;
        public  Dictionary<Section, SectionData> _positions;
        private System.Timers.Timer timer;

        public event EventHandler DriversChanged;
        
        
        //   Dictionairy<Section, SectionData>
        //   <
        //    (Object) Section     [X, Y, Type, Direction] , 
        //    (Object) SectionData [IP Left, DistanceLeft, IP Right, DistanceRight] 
        //   >


        public SectionData GetSectionData(Section section) 
        {
            if (_positions.ContainsKey(section))
            {
                return _positions[section];
            }
            else
            {
                _positions.Add(section, new SectionData());
                return _positions[section];
            }
        } 

        public Race(Track _track, List<IParticipant> _participants)
        {
            track           = _track;
            Participants    = _participants;
            _random         = new Random(DateTime.Now.Millisecond);
            _positions      = new Dictionary<Section, SectionData>();
            giveStartPositions(_track, _participants);
            RandomizeEquipment(_participants);
            SetTimer();
            //trying to subscribe the driverschanged event to the event handler OnDriversChanged
        }

        public int getTravelDistanceOfDriver(Driver d)
        {
            return d.Equipment.Performance * d.Equipment.Speed;
        }

        //at every timed event, move the racers

        private void SetTimer()
        {
            // Create a timer with half second interval.
            timer = new System.Timers.Timer(500);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent; //should be on driverschanged
        //  timer.Elapsed += OnDriversChanged;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        private void Start()
        {
            timer.Enabled = true;
        }
        
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("DriversChanged at {0:HH:mm:ss.fff}", e.SignalTime);
        }


        public void giveStartPositions(Track track, List<IParticipant> participants)
        {
            Queue<Section>      starts     = new Queue<Section>();
           
            foreach (Section section in track.Sections) 
            {
                if(section.SectionType == SectionTypes.StartGrid)
                {
                    starts.Enqueue(section);
                }

                if(section.SectionType == SectionTypes.Finish)
                {
                    break;
                }

            } //loops through this foreach an unnessasery amount of times, should stop after the last startgrid

            int i = 0;

            if((participants.Count % 2) == 0) //amount of participants even or uneven
            {
                while(i < participants.Count) // right now assumes that the number of players is perfectly proportional to the amount of startgrids
                {
                    _positions.Add(starts.Dequeue(), new SectionData(participants[i], participants[i+1])); //rn the number of drivers can only be even      
                    i += 2;
                }
            } else
            {
                while(i < (participants.Count-1)) 
                {
                    _positions.Add(starts.Dequeue(), new SectionData(participants[i], participants[i + 1]));   //uneven fix
                    i += 2;
                }
                    _positions.Add(starts.Dequeue(), new SectionData(participants[i]));
            }
            
            /*
             * can only be placed at a startgrid
             * per startgrid 2 participants
             * first startgrid gets the first 2, etc. Not gonna do 2 at the front, one in the back 
             * 
             */
        }
        public void RandomizeEquipment(List<IParticipant> _participants)     
        {
            foreach(IParticipant ptcpnt in _participants)
            {
                //ptcpnt.Equipment.Performance       = _random.Next();
                // ptcpnt.Equipment.Performance   = _random.Next();
                // ptcpnt.Equipment.Speed         = 40;
            }
        }
    }
}
