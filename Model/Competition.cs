using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Competition
    {
        public List<IParticipant> Participants { get; set; }
        public Queue<Track> Tracks             { get; set; }

        public RaceData<SectionTime> SectionTime { get; set; }
        public RaceData<DriverPoints> DriverPoints { get; set; }
        public RaceData<DriverTime> DriverTime { get; set; }
        public RaceData<DriverAVGspeed> DriverAVGspeed { get; set; }
        public RaceData<FastestLapTime> FastestLapTime { get; set; }

        public Competition()
        {
            Participants    = new List<IParticipant>();
            Tracks          = new Queue<Track>();

            SectionTime     = new RaceData<SectionTime>();
            DriverPoints    = new RaceData<DriverPoints>();
            DriverTime      = new RaceData<DriverTime>();
            DriverAVGspeed  = new RaceData<DriverAVGspeed>();
            FastestLapTime  = new RaceData<FastestLapTime>();
        }


        public Track NextTrack() 
        {
            if (Tracks.Count != 0)
            {
                return Tracks.Dequeue();   
            }
            else
            {
                return null;
            }
        }
    }
}
