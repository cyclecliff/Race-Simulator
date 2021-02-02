using Model;
using System;
using System.Threading;
using static Controller.Race;

namespace Controller
{

    public static class Data
    {
        public static Competition Competition { get; set; }
        public static Race        CurrentRace;

        public static void Initialize() 
        {
            Competition = new Competition();
            addParticipants();
            addTracks();
            NextRace();
        }

        public static void OnRaceFinished(object o, RaceFinishedEventArgs rfe)
        {
            Thread.Sleep(1500);
            Console.Clear();
            NextRace();
            foreach(IParticipant participant in rfe.Participants) //resets the lapscompleted
            {
                participant.LapsCompleted = -1;
                participant.LapTime = new TimeSpan(0);
            }
        }

        public static void NextRace()
        {
            Track t = Competition.NextTrack();
            if(t != null)
            {
                CurrentRace = new Race(t, Competition.Participants);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("N o    T r a c k s    L e f t"); //somehow still draws the track after this
            }
        }

        public static void addParticipants()
        {
            Driver participant1 = new Driver("A", TeamColors.Blue);     //klopt dit?
            Driver participant2 = new Driver("B", TeamColors.Green);
            Driver participant3 = new Driver("C", TeamColors.Grey);
            Driver participant4 = new Driver("D", TeamColors.Red);

           Competition.Participants.Add(participant1);
           Competition.Participants.Add(participant2);
           Competition.Participants.Add(participant3);
           Competition.Participants.Add(participant4);
        }

        public static void addTracks()
        {
            //probably need to rework this later
           
            Track track1 = new Track("H-Vorm 3x3", new[] {  
                                                            SectionTypes.Finish,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.LeftCorner,
                                                            SectionTypes.LeftCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.LeftCorner,
                                                            SectionTypes.LeftCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.StartGrid,
                                                            SectionTypes.StartGrid,
            }); //revamped
            Track track2 = new Track("O-Vorm 3x3", new[] {  
                                                            SectionTypes.Finish,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.StartGrid,
                                                            SectionTypes.StartGrid,
                                                            SectionTypes.StartGrid,

            }); //revamped
            Track track3 = new Track("L-Vorm 3x3", new[] {  
                                                            SectionTypes.Finish,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.LeftCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.StartGrid,
                                                            SectionTypes.StartGrid,
            }); //revamped

            #region //addomtesttracks 

            /*
            Track testtrack1 = new Track("test1", new[] {SectionTypes.StartGrid,
                                                         SectionTypes.StartGrid,
                                                         SectionTypes.Finish,
                                                         SectionTypes.RightCorner,
                                                         SectionTypes.Straight,
                                                         SectionTypes.RightCorner,
                                                         SectionTypes.Straight,
                                                         SectionTypes.Straight,
                                                         SectionTypes.Straight,
                                                         SectionTypes.RightCorner,
                                                         SectionTypes.Straight,
                                                         SectionTypes.RightCorner

                                                        });
            Track testtrack2 = new Track("test2", new[] { SectionTypes.StartGrid,
                                                          SectionTypes.StartGrid,
                                                          SectionTypes.Finish,
                                                          SectionTypes.LeftCorner,
                                                          SectionTypes.Straight,
                                                          SectionTypes.LeftCorner,
                                                          SectionTypes.Straight,
                                                          SectionTypes.Straight,
                                                          SectionTypes.Straight,
                                                          SectionTypes.LeftCorner,
                                                          SectionTypes.Straight,
                                                          SectionTypes.LeftCorner
                                                        });
            
            Competition.Tracks.Enqueue(testtrack1);
            Competition.Tracks.Enqueue(testtrack2);

            */
            
            #endregion

            Competition.Tracks.Enqueue(track1);  //klopt dit?
            Competition.Tracks.Enqueue(track2);
            Competition.Tracks.Enqueue(track3);
        }
    }
}
