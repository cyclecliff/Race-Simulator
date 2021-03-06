﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Track
    {

        public int StartXoffset;

        public int StartYoffset;

        public string Name { get; set; }
        public LinkedList<Section> Sections { get; set; }

        public Track(string name, SectionTypes[] sections)
        {
            Name = name;
            Sections = sectionToLinkedList(sections);
        }

        public LinkedList<Section> sectionToLinkedList(SectionTypes[] sections)
        {
            LinkedList<Section> linkedListSection = new LinkedList<Section>();

            foreach(SectionTypes section in sections)
            {
                linkedListSection.AddLast(new Section(section));
            }

            return linkedListSection;
        }
    }
}
