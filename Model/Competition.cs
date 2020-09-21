using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Competition
    {
        public List<IParticipant> Participants { get; set; }
        Queue<Track> Tracks             { get; set; }

        public Competition()
        {
            Participants = new List<IParticipant>();
            Tracks = new Queue<Track>();
            //Participants.Add
        }

        
        Track NextTrack()
        {
            return Tracks.Dequeue();
        }
    }
}
