using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    using Model;
    using System.Security.Cryptography.X509Certificates;

    public static class Data
    {
        public static Competition Competition { get; set; }

        public static void Initialize() {

            Competition = new Competition();
            addParticipants();
            addTracks();
        
        }

        public static void addParticipants()
        {
           // Competition.Participants.Add();
        }

        public static void addTracks()
        {
          //  Competition.Participants.Add();
        }
    }
}
