using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DriversChangedEventArgs : EventArgs
    {
        public Track track { get; set; }

        public DriversChangedEventArgs(Track _track)
        {
            track = _track;
        }
    }

    public class RaceFinishedEventArgs : EventArgs
    {
      public List<IParticipant> Participants;


    }
}
