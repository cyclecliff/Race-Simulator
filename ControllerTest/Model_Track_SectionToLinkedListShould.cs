﻿using System;
using System.Collections.Generic;
using System.Text;
using Model;
using NUnit.Framework;

namespace ControllerTest
{
    public class Model_Track_SectionToLinkedListShould
    {
        public Track track;
        public Competition competition;

        [SetUp]
        public void SetUp()
        {
            competition = new Competition();
            //track = new Track();

        }

        [Test]
        public void SectionToLinkedList_TwoSections_ReturnTwoList ()
        {
            SectionTypes[] sectiontypes = new[] {    SectionTypes.Straight,
                                                     SectionTypes.StartGrid};

            track = new Track("test_track", sectiontypes);


            var expected =       new LinkedList<Section>();
                expected.AddLast(new Section(SectionTypes.Straight));
                expected.AddLast(new Section(SectionTypes.StartGrid));

            var actual = track.sectionToLinkedList(sectiontypes); //reference not set to instance

            Assert.AreEqual(expected, actual);
        }
    }
}
