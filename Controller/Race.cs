using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Diagnostics;

namespace Controller
{
    public class Race
    {
        public Track track;
        public List<IParticipant> Participants;
        public DateTime StartTime;
        private static Random _random;
        public Dictionary<Section, SectionData> _positions;
        private System.Timers.Timer timer;
        private Stopwatch stopwatch; //to get the laptime
        public int LapsAmount;
        public int ParticipantsOnTrack;
        public LinkedList<Driver> eindstand;
      //public delegate EventHandler DriversChanged(object sender, DriversChangedEventArgs d);

        public delegate void DriversChanged(object sender, DriversChangedEventArgs d);

        public delegate void RaceFinished(object sender, RaceFinishedEventArgs e);

        public event DriversChanged Drivers_Changed;

        public event RaceFinished Race_Finished;

        public Race(Track _track, List<IParticipant> _participants)
        {
            track = _track;
            LapsAmount = 1;
            Participants = _participants;
            ParticipantsOnTrack = Participants.Count();
            _random = new Random(DateTime.Now.Millisecond);
            _positions = new Dictionary<Section, SectionData>();
            giveStartPositions(_track, _participants);
            RandomizeEquipment(_participants);
            SetTimer(); //already starts invoking ondriverschanged
            stopwatch = new Stopwatch();
            stopwatch.Start();
            eindstand = new LinkedList<Driver>(); //drivers in order of finishing
            //trying to subscribe the driverschanged event to the event handler OnDriversChanged
        }

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
        public static void ShouldBeBroken(IEquipment car) //breaks down cars and undoes it
        {
            int randomnumber = _random.Next(1, 20);

            bool originallybroken = car.IsBroken;

            car.IsBroken = (car.Quality + car.Performance > randomnumber); //the higher the quality and the performance, the less change the car'll break down

            if (!originallybroken && car.IsBroken) //car not broken when i comes in but broken now
            {
                car.Performance -= _random.Next((int)0.1, (int)0.5); //performance gets worse after each breakdown
            } 
            //each time a car is turned from unbroken to broken, adjust a value
        }

        public virtual void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            timer.Stop();
            ///Console.WriteLine("DriversChanged at {0:HH:mm:ss.fff}", e.SignalTime);
            
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

                                ShouldBeBroken(MovingDriver.Equipment); //chance that this will break the car

                                //Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged

                                if (i == _positions.Count - 1)                              //is hij aan het "einde" van de track
                                {
                                    
                                    

                                    if (_positions.ElementAt(0).Value.Left == null && !MovingDriver.Equipment.IsBroken)         //kan ik vooruit (naar het begin)
                                    {
                                        LapCompletedTest(MovingDriver);

                                        MovingDriver.LapTime += (stopwatch.Elapsed - MovingDriver.LapTime);
                                        
                                        if (MovingDriver.LapsCompleted == LapsAmount) //ronden zijn gereden, driver verdwijnt
                                        {
                                            ParticipantsOnTrack--;
                                            eindstand.AddLast((Driver)MovingDriver); //adds the finished driver to the eindstand list
                                           
                                        }
                                        else
                                        {
                                            _positions.ElementAt(0).Value.Left = MovingDriver;
                                            _positions.ElementAt(0).Value.DistanceLeft = leftDistance - 200;
                                        }
                                        data.DistanceLeft = 0;
                                        data.Left = null;
                                        //Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
                                    }
                                    else if (_positions.ElementAt(0).Value.Right == null && !MovingDriver.Equipment.IsBroken)    //kan ik van baan wisselen (naar het begin)
                                    {
                                        LapCompletedTest(MovingDriver);

                                        MovingDriver.LapTime += (stopwatch.Elapsed - MovingDriver.LapTime);
                                        
                                        if (MovingDriver.LapsCompleted == LapsAmount) //ronden zijn gereden, driver verdwijnt
                                        {
                                            ParticipantsOnTrack--;
                                            eindstand.AddLast((Driver)MovingDriver);
                                        }
                                        else
                                        {
                                            _positions.ElementAt(0).Value.Right = MovingDriver;
                                            _positions.ElementAt(0).Value.DistanceRight = leftDistance - 200;
                                          
                                        }
                                        data.DistanceLeft = 0;
                                        data.Left = null;
                                        //Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
                                    }
                                    else
                                    {
                                        data.DistanceLeft = 0;//ik kan niet inhalen en niet doorrijden of isbroken: distance wordt gereset
                                        //Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
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
                                        //Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track));
                                        break;
                                    }
                                    else if (_positions.ElementAt(i + 1).Value.Right == null)    //kan ik van baan wisselen 
                                    {
                                        _positions.ElementAt(i + 1).Value.Right = MovingDriver;
                                        _positions.ElementAt(i + 1).Value.DistanceRight = leftDistance - 200;
                                        data.DistanceLeft = 0;
                                        data.Left = null;
                                        //Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track));
                                        break;
                                    }                                                           
                                        
                                    else
                                    {
                                        data.DistanceLeft = 0; //ik kan niet inhalen en niet doorrijden : distance wordt gereset
                                        //Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        data.DistanceLeft += leftDistance;
                        //Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
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

                                ShouldBeBroken(MovingDriver.Equipment); //chance that this will break the car

                                //Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged

                                if (i == _positions.Count - 1)                              //is hij aan het "einde" van de track
                                {
                                    if (_positions.ElementAt(0).Value.Right == null && !MovingDriver.Equipment.IsBroken)         //kan ik vooruit (naar het begin)
                                    {
                                        LapCompletedTest(MovingDriver);

                                        MovingDriver.LapTime += (stopwatch.Elapsed - MovingDriver.LapTime);
                                        
                                        if (MovingDriver.LapsCompleted == LapsAmount) //ronden zijn gereden, driver verdwijnt
                                        {
                                            ParticipantsOnTrack--;
                                            eindstand.AddLast((Driver)MovingDriver);
                                        }
                                        else
                                        {
                                            _positions.ElementAt(0).Value.Right = MovingDriver;
                                            _positions.ElementAt(0).Value.DistanceRight = rightDistance - 200;
                                        }
                                        data.DistanceRight = 0;
                                        data.Right = null;
                                        //Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
                                    }
                                    else if (_positions.ElementAt(0).Value.Left == null && !MovingDriver.Equipment.IsBroken)    //kan ik van baan wisselen (naar het begin)
                                    {
                                        LapCompletedTest(MovingDriver);

                                        MovingDriver.LapTime += (stopwatch.Elapsed - MovingDriver.LapTime);
                                        
                                        if (MovingDriver.LapsCompleted == LapsAmount) //ronden zijn gereden, driver verdwijnt
                                        {
                                            ParticipantsOnTrack--;
                                            eindstand.AddLast((Driver)MovingDriver);
                                        }
                                        else
                                        {
                                            _positions.ElementAt(0).Value.Left = MovingDriver;
                                            _positions.ElementAt(0).Value.DistanceLeft = rightDistance - 200;

                                        }
                                        data.DistanceRight = 0;
                                        data.Right = null;
                                        //Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
                                    }
                                    else
                                    {
                                        data.DistanceRight = 0;//ik kan niet inhalen en niet doorrijden of isbroken: distance wordt gereset
                                        //Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
                                    }
                                }
                                else                                                             //hij is niet aan het einde
                                {
                                    if (_positions.ElementAt(i + 1).Value.Right == null)         //kan ik vooruit 
                                    {
                                        _positions.ElementAt(i + 1).Value.Right = MovingDriver;
                                        _positions.ElementAt(i + 1).Value.DistanceRight = rightDistance - 200;
                                        data.DistanceRight = 0;
                                        data.Right = null;
                                        //Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track));
                                        break;
                                    }
                                    else if (_positions.ElementAt(i + 1).Value.Left == null)    //kan ik van baan wisselen 
                                    {
                                        _positions.ElementAt(i + 1).Value.Left = MovingDriver;
                                        _positions.ElementAt(i + 1).Value.DistanceLeft = rightDistance - 200;
                                        data.DistanceRight = 0;
                                        data.Right = null;
                                        //Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track));
                                        break;
                                    }

                                    else
                                    {
                                        data.DistanceRight = 0; //ik kan niet inhalen en niet doorrijden : distance wordt gereset
                                        //Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        data.DistanceRight += rightDistance;
                        //Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged
                    }
                }
            }
            //GiveData();
            Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track)); //activates OnDriversChanged

            timer.Start();
            if (RaceEnded_NoParticipantsLeft())
            {
                timer.Stop();
                stopwatch.Reset();
                GiveData();
                Drivers_Changed?.Invoke(this, new DriversChangedEventArgs(track));
                CleanupDelegates(); 
                Race_Finished?.Invoke(this, new RaceFinishedEventArgs() { Participants = Participants});
            }
        }

        public void GiveData()
        {
                Data.Competition.GiveLapTimes(Participants);
                Data.Competition.GiveTimeDifference(Participants, GetEindstand());
                Data.Competition.GiveAvgSpeed(track, Participants);
                Data.Competition.GivePoints(GetEindstand()); //loopt vast hier
        }

        public void CleanupDelegates()
        {
           // Drivers_Changed -= OnDriversChanged;
           foreach(DriversChanged d in Drivers_Changed.GetInvocationList())
           {
                Drivers_Changed -= d;
           }
        }
        public int getTravelDistanceOfDriver(Driver d)
        {
            return d.Equipment.Performance * d.Equipment.Speed;
        }
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

        public int y = 40;
        public void LapCompletedTest(IParticipant driver)
        {
            driver.LapsCompleted++;
            Console.SetCursorPosition(0, y);
            //Console.Write($"Driver {driver.Name} has completed a lap in {driver.LapTime.TotalSeconds} seconds. Lap nr: {driver.LapsCompleted}"); //program seems to go back in time and change the lapscompleted of a driver. (multithreading issue?)
            y++;
        }
        public bool RaceEnded_NoParticipantsLeft()
        {
            return ParticipantsOnTrack == 0;
        }
        public bool RaceEnded_LapsCompleted(Track track)
        {
            bool RaceEnded = false;
            //another way, each time a participant gets deleted, change a counter, when the counter equals zero, the race stops

            foreach(Section section in track.Sections)
            {
                SectionData data = GetSectionData(section);

                RaceEnded = data == null;
            }
            return RaceEnded;
            
        }
        public LinkedList<Driver> GetEindstand()
        {
            return eindstand;
        }

        //   Dictionairy<Section, SectionData>
        //   <
        //    (Object) Section     [X, Y, Type, Direction] , 
        //    (Object) SectionData [IP Left, DistanceLeft, IP Right, DistanceRight] 
        //   >

        //public virtual void MoveDrivers(Track track) //breedte van een sectie is 100
        //{
        //    //Console.WriteLine("drivers were moved"); works
        //}

        public void giveStartPositions(Track track, List<IParticipant> participants)//refactor so that the finish is the first section in the _positions list
        {
            Queue<IParticipant> participantz = new Queue<IParticipant>(participants);

            foreach (Section section in track.Sections) 
            {
                if (section.SectionType == SectionTypes.StartGrid)  //3 startgrids
                {
                    if (participantz.Count >= 2)
                    {
                        _positions.Add(section, new SectionData(participantz.Dequeue(), participantz.Dequeue())); //rn the number of drivers can only be even      
                    
                    } else if (participantz.Count == 1)
                    {
                        _positions.Add(section, new SectionData(participantz.Dequeue()));
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
