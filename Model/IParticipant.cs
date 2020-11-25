using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IParticipant
    {
        string Name             { get; set; }
        int Points              { get; set; }
        int LapsCompleted       { get; set; }
        IEquipment Equipment    { get; set; }
        TeamColors TeamColor    { get; set; }
    }
}
