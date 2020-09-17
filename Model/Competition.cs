using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class Competition
    {
        List<IParticipant> Participants { get; set; }
        Queue<Track> Tracks             { get; set; }



        public Track NextTrack()
        {
            return null;
        }
    }
}
