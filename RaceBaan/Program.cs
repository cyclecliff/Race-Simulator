using Controller;
using Model;
using System;
using System.Threading;

namespace RaceBaan
{
    public class Program 
    {
        public static void SubscribeEvents()
        {
            Data.CurrentRace.Drivers_Changed += Visualization.OnDriversChanged;
            Data.CurrentRace.Race_Finished += Data.OnRaceFinished;
            
            //Data.CurrentRace.Race_Finished += 
        }

        public static void OnFinishedRace(object source, EventArgs args)
        {
            SubscribeEvents();
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Data.Initialize();
            Visualization.Initialize();
            SubscribeEvents();
            

            while(true)
            {
                Thread.Sleep(100);
            }
        }
    }
}
