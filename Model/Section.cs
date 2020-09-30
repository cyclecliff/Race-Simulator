using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Section
    {
        SectionTypes SectionType { get; set;  }

        public Section(SectionTypes sectionType)
        {
            SectionType = sectionType;
        }
    }
}
