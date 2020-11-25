using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Driver : IParticipant
    {
        public string     Name          { get; set; }
        public int        Points        { get; set; }
        public IEquipment Equipment     { get; set; }   
        public TeamColors TeamColor     { get; set; }
        public int        LapsCompleted { get; set; }

        public Driver(String _name, TeamColors _teamcolor) //each driver gets a letter
        {
            Name            = _name;
            Points          = 0;
            TeamColor       = _teamcolor;
            Equipment       = new Car();
            LapsCompleted   = -1; //passes the finish after start
        }
    }
}
