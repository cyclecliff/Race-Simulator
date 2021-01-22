using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Competition
    {
        public List<IParticipant> Participants { get; set; }
        public Queue<Track> Tracks             { get; set; }

        public RaceData<DriverPoints> DriverPoints      { get; set; }
        public RaceData<DriverLapTime> DriverLapTime { get; set; }
        public RaceData<DriverTimeDifference> DriverTimeDifference { get; set; }
        public RaceData<DriverAverageSpeed> DriverAverageSpeed { get; set; }


        public Competition()
        {
            Participants         = new List<IParticipant>();
            Tracks               = new Queue<Track>();
            
            DriverPoints         = new RaceData<DriverPoints>();
            DriverLapTime        = new RaceData<DriverLapTime>();
            DriverTimeDifference = new RaceData<DriverTimeDifference>();
            DriverAverageSpeed   = new RaceData<DriverAverageSpeed>();
        }
        

        public void GiveAvgSpeed(Track track, List<IParticipant> participants) //takes each roudntime and divides it by the track length
        {
            int tracklength = track.Sections.Count * 200; // length of one section is 200 meters

            foreach(Driver driver in participants)
            {
                DriverAverageSpeed avgspeeddriver = new DriverAverageSpeed();
                avgspeeddriver.Name  = driver.Name;
                avgspeeddriver.Speed = tracklength / driver.LapTime.Seconds; //meters per second
                DriverAverageSpeed.AddItemToList(avgspeeddriver);
            }

            
        }

        public void GiveLapTimes(List<IParticipant> participants)
        {
            foreach(Driver driver in participants)
            {
                DriverLapTime lptdriver = new DriverLapTime();
                lptdriver.Name = driver.Name;
                lptdriver.Time = driver.LapTime;
                DriverLapTime.AddItemToList(lptdriver);
                driver.LapTime = new TimeSpan(0,00,00);
            }
        }
        
        public void GiveTimeDifference(List<IParticipant> participants, LinkedList<Driver> eindstand)
        {
            List<IParticipant> eindstandlist = new List<IParticipant>(); //turn LinkedList into a List in order to make it accesible by index
            foreach(Driver driver in eindstand)
            {
                eindstandlist.Add(driver);
            }

            for(int i = 0; i < eindstandlist.Count; i++)
            {
                DriverTimeDifference tmdffdriver = new DriverTimeDifference();
                tmdffdriver.Name = eindstandlist[i].Name;
                if(i == 0)
                {
                    tmdffdriver.TimeDifference = eindstandlist[i + 1].LapTime - eindstandlist[i].LapTime; //time difference between the front runner and the 2nd up
                }
                else
                {
                    tmdffdriver.TimeDifference = eindstandlist[i].LapTime - eindstandlist[0].LapTime; //time difference with the front runner
                }
                DriverTimeDifference.AddItemToList(tmdffdriver);
            }


            //eerste
            //wat is je tijdsverschil met de tweede, 
            //geef

            //tweede, 
            //wat is je tijdsverschil met de eerste
            //geef

            //enz

            
        }

        public void GivePoints(LinkedList<Driver> eindstand)    //takes the list of finished drivers and makes DriverPoints objects, 
        {                                                 //allocates points and adds them to the List<T>

            //List<IDataTemplate> list = new List<IDataTemplate>();
            int x = eindstand.Count;
            for (int i = 0; i < x; i++)
            {
                DriverPoints ptsdriver = new DriverPoints();
                ptsdriver.Name = eindstand.First.Value.Name;
                eindstand.RemoveFirst(); //x--;
                if(i == 0)  {ptsdriver.Points = 3;}
                if(i == 1)  {ptsdriver.Points = 2;}     
                if(i >= 2)  {ptsdriver.Points = 1;}
                DriverPoints.AddItemToList(ptsdriver);
            }
        }

        public Track NextTrack() 
        {
            if (Tracks.Count != 0)
            {
                return Tracks.Dequeue();   
            }
            else
            {
                return null;
            }
        }
    }
}
