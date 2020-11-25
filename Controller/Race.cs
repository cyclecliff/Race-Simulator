using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace Controller
{
    public class Race
    {
        public Track track;
        public List<IParticipant> Participants;
        public DateTime StartTime;
        private Random _random;
        public Dictionary<Section, SectionData> _positions;
        private System.Timers.Timer timer;
        // public delegate EventHandler DriversChanged(object sender, DriversChangedEventArgs d);


        public delegate void DriversChanged(object sender, DriversChangedEventArgs d);

        public event DriversChanged Drivers_Changed;

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
            track = _track;
            Participants = _participants;
            _random = new Random(DateTime.Now.Millisecond);
            _positions = new Dictionary<Section, SectionData>();
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
            timer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent; //should be on driverschanged
            //timer.Elapsed += OnDriversChanged;
            timer.AutoReset = true;
            timer.Enabled = true;
        }


        public virtual void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            timer.Stop();
            //Console.WriteLine("DriversChanged at {0:HH:mm:ss.fff}", e.SignalTime);
            foreach (Section section in track.Sections)
            {
                SectionData data = GetSectionData(section);

                if (data.Left != null)
                {
                    int leftDistance = data.DistanceLeft + getTravelDistanceOfDriver((Driver)data.Left); //berekent te reizen afstand. works

                    if (leftDistance > 200)
                    {
                        for (int i = 0; i < _positions.Count; i++)
                        {
                            if (_positions.ElementAt(i).Value.Left == data.Left) //if the left contains the participant im looking for
                            {
                                var MovingDriver = _positions.ElementAt(i).Value.Left;

                                if (i == _positions.Count - 1)                              //is hij aan het "einde" van de track
                                {
                                    if (_positions.ElementAt(0).Value.Left == null)         //kan ik vooruit (naar het begin)
                                    {
                                        MovingDriver.LapsCompleted++;
                                        _positions.ElementAt(0).Value.Left = MovingDriver;
                                        _positions.ElementAt(0).Value.DistanceLeft = leftDistance - 200;
                                        data.DistanceLeft = 0;
                                        data.Left = null;
                                        Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
                                        break;
                                    }
                                    else if (_positions.ElementAt(0).Value.Right == null)    //kan ik van baan wisselen (naar het begin)
                                    {
                                        MovingDriver.LapsCompleted++;
                                        _positions.ElementAt(0).Value.Right = MovingDriver;
                                        _positions.ElementAt(0).Value.DistanceRight = leftDistance - 200;
                                        data.DistanceLeft = 0;
                                        data.Left = null;
                                        Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
                                        break;
                                    }
                                    else
                                    {
                                        data.DistanceLeft = 0;//ik kan niet inhalen en niet doorrijden : distance wordt gereset
                                    }
                                    
                                }
                                else                                                             //hij is niet aan het einde
                                {
                                    if (_positions.ElementAt(i + 1).Value.Left == null)         //kan ik vooruit 
                                    {
                                        
                                        _positions.ElementAt(i + 1).Value.Left = MovingDriver;
                                        _positions.ElementAt(i + 1).Value.DistanceLeft = leftDistance - 200;
                                        data.DistanceLeft = 0;
                                        data.Left = null;
                                        Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
                                        break;
                                    }
                                    else if (_positions.ElementAt(i + 1).Value.Right == null)    //kan ik van baan wisselen 
                                    {
                                        
                                        _positions.ElementAt(i + 1).Value.Right = MovingDriver;
                                        _positions.ElementAt(i + 1).Value.DistanceRight = leftDistance - 200;
                                        data.DistanceLeft = 0;
                                        data.Left = null;
                                        Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
                                        break;
                                    }                                                           
                                    else
                                    {
                                        data.DistanceLeft = 0; //ik kan niet inhalen en niet doorrijden : distance wordt gereset
                                    }
                                }

                            }

                        }
                    }
                    else
                    {
                        data.DistanceLeft += leftDistance;
                    }
                }
                if (data.Right != null)
                {
                    int rightDistance = data.DistanceRight + getTravelDistanceOfDriver((Driver)data.Right); //berekent te reizen afstand. works

                    if (rightDistance > 200)
                    {
                        for (int i = 0; i < _positions.Count; i++)
                        {
                            if (_positions.ElementAt(i).Value.Right == data.Right) //if the left contains the participant im looking for
                            {
                                var MovingDriver = _positions.ElementAt(i).Value.Right;

                                if (i == _positions.Count - 1)                              //is hij aan het "einde" van de track
                                {
                                    if (_positions.ElementAt(0).Value.Right == null)         //kan ik vooruit (naar het begin)
                                    {
                                        MovingDriver.LapsCompleted++;
                                        _positions.ElementAt(0).Value.Right = MovingDriver;
                                        _positions.ElementAt(0).Value.DistanceRight = rightDistance - 200;
                                        data.DistanceRight = 0;
                                        data.Right = null;
                                        Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
                                        break;
                                    }
                                    else if (_positions.ElementAt(0).Value.Left == null)    //kan ik van baan wisselen (naar het begin)
                                    {
                                        MovingDriver.LapsCompleted++;
                                        _positions.ElementAt(0).Value.Left = MovingDriver;
                                        _positions.ElementAt(0).Value.DistanceLeft = rightDistance - 200;
                                        data.DistanceRight = 0;
                                        data.Right = null;
                                        Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
                                        break;
                                    }
                                    else
                                    {
                                        data.DistanceRight = 0; //ik kan niet inhalen en niet doorrijden : distance wordt gereset
                                    }
                                   
                                }
                                else                                                             //hij is niet aan het einde
                                {
                                    if (_positions.ElementAt(i + 1).Value.Right == null)         //kan ik vooruit (naar het begin)
                                    {
                                        
                                        _positions.ElementAt(i + 1).Value.Right = MovingDriver;
                                        _positions.ElementAt(i + 1).Value.DistanceRight = rightDistance - 200;
                                        data.DistanceRight = 0;
                                        data.Right = null;
                                        Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
                                        break;
                                    }
                                    else if (_positions.ElementAt(i + 1).Value.Left == null)    //kan ik van baan wisselen (naar het begin)
                                    {
                                        
                                        _positions.ElementAt(i + 1).Value.Left = MovingDriver;
                                        _positions.ElementAt(i + 1).Value.DistanceLeft = rightDistance - 200;
                                        data.DistanceRight = 0;
                                        data.Right = null;
                                        Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
                                        break;
                                    }                                                            
                                    else
                                    {
                                        data.DistanceRight = 0;//ik kan niet inhalen en niet doorrijden : distance wordt gereset
                                    }
                                }

                            }

                        }
                    }
                    else
                    {
                        data.DistanceRight += rightDistance;
                    }

                    /*
                    if (_positions.ElementAt(i + 1).Value.Left == null)//kan ik vooruit
                    {

                    }

                    else if(_positions.ElementAt(i + 1).Value.Left == null)//kan ik vooruit naar de andere baanhelft?
                    {

                    }
                    */
                    //else if(_positions.ElementAt(i).Value.Right == null)//kan ik naar de andere baan (distance blijft 0)
                    //{ mooi idee, maak mezelf niet te ingewikkeld

                    // }

                    //positions.Remove(participant)
                    //positions.ElementAt(i).Value.Left == null; ;


                    //niet bewegen als het volgende vakje bezet is, en als inhalen ook onmogelijk is (van left <> right)





                }
                
            }
            timer.Start();
        }
        //   Dictionairy<Section, SectionData>
        //   <
        //    (Object) Section     [X, Y, Type, Direction] , 
        //    (Object) SectionData [IP Left, DistanceLeft, IP Right, DistanceRight] 
        //   >

        public virtual void MoveDrivers(Track track) //breedte van een sectie is 100
        {
            //Console.WriteLine("drivers were moved"); works

            
        }

       
       


        public void giveStartPositions(Track track, List<IParticipant> participants)
            //refactor so that the finish is the first section in the _positions list
        {
            foreach (Section section in track.Sections) 
            {

                if(section.SectionType == SectionTypes.StartGrid)
                {
                    int i = 0;

                    if((participants.Count % 2) == 0) //amount of participants even or uneven
                    {
                       while(i < participants.Count) // right now assumes that the number of players is perfectly proportional to the amount of startgrids
                       {
                           _positions.Add(section, new SectionData(participants[i], participants[i+1])); //rn the number of drivers can only be even      
                           i += 2; //wants to add parts to the same section
                       }
                    } else
                    {
                        while(i < (participants.Count-1)) 
                        {
                           _positions.Add(section, new SectionData(participants[i], participants[i + 1]));   //uneven fix
                           i += 2;
                        }
                         _positions.Add(section, new SectionData(participants[i]));
                    }
                    
                } else
                {
                    _positions.Add(section, new SectionData());
                }
               
                //if(section.SectionType != SectionTypes.StartGrid)
                //{
                //    break;
                //}

            } //loops through this foreach an unnessasery amount of times, should stop after the last startgrid

            
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
                 ptcpnt.Equipment.Quality       = _random.Next(1, 5);
                 ptcpnt.Equipment.Performance   = _random.Next(1, 5);
                 ptcpnt.Equipment.Speed         = 20;
            }
        }
    }
}
