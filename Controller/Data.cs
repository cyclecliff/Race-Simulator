namespace Controller
{
    using Model;

    public static class Data
    {
        public static Competition Competition { get; set; }
        public static Race        CurrentRace;

        public static void Initialize() {

            Competition = new Competition();
            addParticipants();
            addTracks();
        }


        public static void NextRace()
        {
            Track t = Competition.NextTrack();
            if(!(t == null))
            {
                CurrentRace = new Race(t, Competition.Participants);
            }
        }


        public static void addParticipants()
        {
            Driver participant1 = new Driver();     //klopt dit?
            Driver participant2 = new Driver();
            Driver participant3 = new Driver();

           Competition.Participants.Add(participant1);
           Competition.Participants.Add(participant2);
           Competition.Participants.Add(participant3);
        }

        public static void addTracks()
        {
            //probably need to rework this later
           
            Track track1 = new Track("H-Vorm 3x3", new[] {  SectionTypes.StartGrid,
                                                            SectionTypes.StartGrid,
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
            }); //revamped
            Track track2 = new Track("O-Vorm 3x3", new[] {  SectionTypes.StartGrid,
                                                            SectionTypes.StartGrid,
                                                            SectionTypes.Finish,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner

            }); //revamped
            Track track3 = new Track("L-Vorm 3x3", new[] {  SectionTypes.StartGrid,
                                                            SectionTypes.StartGrid,
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
                                                            SectionTypes.Straight
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
