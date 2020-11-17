using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Driver : IParticipant
    {
        public string Name              { get; set; }
        public int Points               { get; set; }
        public IEquipment Equipment     { get; set; }
        public TeamColors TeamColor     { get; set; }


        public Driver(String _name, TeamColors _teamcolor) //each driver gets a letter
        {
            //standaard snelheid
            Name      = _name;
            Points    = 0;
            TeamColor = _teamcolor;
            
          // Equipment.Speed;
        }
    }
}
