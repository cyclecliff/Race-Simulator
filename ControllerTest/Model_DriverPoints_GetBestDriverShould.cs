using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace ControllerTest { 

    [TestFixture]
    public class Model_DriverPoints_GetBestDriverShould
    {
        public Competition _competition;

        [SetUp]
        public void SetUp()
        {
            _competition = new Competition();
            
        }

        [Test]
        public void GetBestDriverGetBestOneAdd()
        {

            string meest = "meest";

            _competition.DriverPoints.AddItemToList(new DriverPoints() { Name = "minst", Points = 1 });
            _competition.DriverPoints.AddItemToList(new DriverPoints() { Name = "meest", Points = 99 });


            DriverPoints x = new DriverPoints(){ Name = "meest", Points = 99 };

            string winner = x.GetBestDriverName(_competition.DriverPoints.list);

            Assert.AreEqual(meest, winner);
            
        }

        [Test]
        public void GetBestDriverGetBestDoubleAdd()
        {

            string meest = "meest";

            _competition.DriverPoints.AddItemToList(new DriverPoints() { Name = "minst", Points = 1 });
            _competition.DriverPoints.AddItemToList(new DriverPoints() { Name = "meest", Points = 99 });
            _competition.DriverPoints.AddItemToList(new DriverPoints() { Name = "minst", Points = 99});
            _competition.DriverPoints.AddItemToList(new DriverPoints() { Name= "meest", Points = 99 });


            DriverPoints x = new DriverPoints() { Name = "meest", Points = 99 };

            //string winner = x.GetBestDriver(_competition.DriverPoints.list);

            //Assert.AreEqual(meest, winner);

        }

        [Test]
        public void GetBestDriverNoAdd()
        {

            string meest = null;

            DriverPoints x = new DriverPoints() { Name = "meest", Points = 99 };

            string winner = x.GetBestDriverName(_competition.DriverPoints.list);

            Assert.AreEqual(meest, null);

        }
    }
}
