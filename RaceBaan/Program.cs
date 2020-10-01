using Controller;
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
            Console.WriteLine(Data.CurrentRace.track.Name);


            Console.WriteLine(" \\ ");
            for(; ; )
            {
                Thread.Sleep(100);
            }


        }
    }
}
