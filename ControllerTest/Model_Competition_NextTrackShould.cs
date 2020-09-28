using Betfair_API_NG.TO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerTest { using Model ;

    [TestFixture]
    public class Model_Competition_NextTrackShould
    {
        public Competition _competition;

        [SetUp]
        public void SetUp()
        {
            _competition = new Competition();
        }

        [Test]
        public void NextTrack_EmptyQueue_ReturnNull()
        {
            var result = _competition.NextTrack();
            Assert.IsNull(result);
        }

        [Test]
        public void NextTrack_OneInQueue_ReturnTrack()
        {
            _competition.Tracks.Enqueue(new Track());
            var result = _competition.NextTrack();

            Assert.AreEqual(_competition.Tracks.Dequeue(), result);   
        }

    }
}
