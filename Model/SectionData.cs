﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SectionData
    {
        IParticipant Left   { get; set; }
        int DistanceLeft    { get; set; }
        IParticipant Right  { get; set; }
        int DistanceRight   { get; set; }

    }
}
