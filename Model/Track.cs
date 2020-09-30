using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Track
    {

        public string Name { get; set; }
        public LinkedList<Section> Sections { get; set; }

        public Track(string name, SectionTypes[] sections)
        {
            Name = name;
            //Sections = sections;
        }

        public LinkedList<Section> sectionToLinkedList(SectionTypes[] sectiontypes)
        {
            LinkedList<Section> sectionlist = new LinkedList<Section>();

            foreach(SectionTypes Section in sectiontypes)
            {
                Section section = new Section(Section);
                sectionlist.AddLast(section); //somehow turn sectiontype into section
            }

            return sectionlist;
        }

        

        

    }
}
