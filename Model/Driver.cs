using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Model
{
    public class Driver : IParticipant
    {
        public string     Name          { get; set; }
        public int        Points        { get; set; }
        public IEquipment Equipment     { get; set; }   
        public TeamColors TeamColor     { get; set; }
        public int        LapsCompleted { get; set; }
        public TimeSpan   LapTime       { get; set; }

        public Driver(String _name, TeamColors _teamcolor) //each driver gets a letter
        {
            Name            = _name;
            Points          = 0;
            TeamColor       = _teamcolor;
            Equipment       = new Car();
            LapsCompleted   = -1; //passes the finish after start, so becomes 0
            LapTime         = new TimeSpan(0,00,00); //seconds
        }
    }
}
