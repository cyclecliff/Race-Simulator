using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class DriverTimeDifference : IDataTemplate //hoeveel seconden ligt hij voor of achter op de 1e bij het finishen
    {
        public string Name { get; set; }
        public TimeSpan TimeDifference { get; set; } //positive or negative

        public void AddToList(List<IDataTemplate> list)
        {
            var item = list.FirstOrDefault(i => i.Name.Equals(Name));
            var x = (DriverTimeDifference)item;
            if (item != null)
            {
                x.TimeDifference += TimeDifference;
            }
            else
            {
                list.Add(this); //i have no clue what im doing
            }
        }

        public string GetBestDriverName(List<IDataTemplate> list)
        {
            DriverTimeDifference best = new DriverTimeDifference();


            foreach(DriverTimeDifference driver in list) //not correct
            {
                if(best.TimeDifference < driver.TimeDifference)
                {
                    best.TimeDifference = driver.TimeDifference;
                }
            }
            return best.Name;
        }
    }


    public class DriverLapTime : IDataTemplate
    {
        public string Name { get; set; }
        public TimeSpan Time { get; set; }

        public void AddToList(List<IDataTemplate> list)
        {
            var item = list.FirstOrDefault(i => i.Name.Equals(Name));
            var x = (DriverLapTime)item;
            if (item != null)
            {
                x.Time += Time;
            }
            else
            {
                list.Add(this); //i have no clue what im doing
            }
        }

        public string GetBestDriverName(List<IDataTemplate> list) // IN AVERAGE LAP TIME
        {
            //get the driver with the best average lap time by dividing the total lap time by the amount of laps

            DriverLapTime bestedriver = new DriverLapTime();

            int laps = 3; //hardcoded, dont know how to reach lapsamount from here

            foreach (DriverLapTime driver in list)
            {
                
                int driverseconds = (int)driver.Time.TotalSeconds;
                int besteseconds = (int)bestedriver.Time.TotalSeconds;

                if ((driverseconds / laps) > (besteseconds  / laps))
                {
                    bestedriver = driver;
                }
            }
            return bestedriver.Name;
        }
    }


    public class DriverPoints : IDataTemplate
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public void AddToList(List<IDataTemplate> list)
        {
            //jlist.Add(this);

            //get name of list and compare it to the this.name
            //DriverPoints driver = (DriverPoints)list.First(x => x.Naam.Equals(this.Naam));
            var item = list.FirstOrDefault(i => i.Name.Equals(Name));
            var x = (DriverPoints)item;
            if (item != null)
            {
                x.Points += Points;
            } else
            {
                list.Add(this); //i have no clue what im doing
            }

        }

        public string GetBestDriverName(List<IDataTemplate> list)  // IN POINTS
        {
            DriverPoints bestedriver = new DriverPoints();
            
            foreach(DriverPoints driver in list)
            {
                if(driver.Points > bestedriver.Points)
                {
                    bestedriver = driver;        
                }
            }
            return bestedriver.Name;
        }
    }
}