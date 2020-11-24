using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Car : IEquipment
    {
        //voegt aan je driver een nieuwe auto toe
        public int Quality      { get; set; }
        public int Performance  { get; set; }
        public int Speed        { get; set; }
        public bool IsBroken    { get; set; }
    }
}
