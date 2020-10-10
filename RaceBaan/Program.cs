using Controller;
using Model;
using System;
using System.Threading;

namespace RaceBaan
{
    public class Program 
    {

        static void Main(string[] args)
        { 
            Data.Initialize();
            Data.NextRace();
           //Console.WriteLine(Data.CurrentRace.track.Name);

            Data.addTracks();

            Visualization.DrawTrack(Data.CurrentRace.track);
            
       





            for (; ; )
            {
                Thread.Sleep(100);
            }


        }
    }
}
