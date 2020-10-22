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
            //Data.NextRace();

            Data.addTracks();

            Visualization.SetTrackData(Data.CurrentRace.track, Direction.Right);
            //Data.CurrentRace.giveStartPositions(Data.CurrentRace.track, Data.CurrentRace.Participants);
            Visualization.DrawTrack(Data.CurrentRace.track);
            




            for (; ; )
            {
                Thread.Sleep(100);
            }


        }
    }
}
