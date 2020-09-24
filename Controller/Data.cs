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
            return new Race(Competition.NextTrack(), );//ffs get help friday
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

            Track track1 = new Track("H-Vorm 3x3", new[] {  SectionTypes.StartGrid, 
                                                            SectionTypes.Straight, 
                                                            SectionTypes.RightCorner, 
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.LeftCorner,
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
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.LeftCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.LeftCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Finish
            });
            Track track2 = new Track("O-Vorm 3x3", new[] {  SectionTypes.StartGrid,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Finish

            });
            Track track3 = new Track("L-Vorm 3x3", new[] {  SectionTypes.StartGrid,
                                                            SectionTypes.Straight,
                                                            SectionTypes.LeftCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.LeftCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.LeftCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.RightCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.LeftCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.LeftCorner,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Straight,
                                                            SectionTypes.Finish
            });


            Competition.Tracks.Enqueue(track1);  //klopt dit?
            Competition.Tracks.Enqueue(track2);
            Competition.Tracks.Enqueue(track3);
        }
    }
}
