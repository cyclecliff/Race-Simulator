using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class RaceData<T> where T : IDataTemplate
    {

        private List<T> _list = new List<T>();

        private void addToList(T variable)
        {
            _list.Add(variable);
        }

    }

    /*
    public class DriverPoints<T>
    {
        private string      naam;
        private int         points;
    }

    public class DriverTimes<T>
    {
        private string      naam;
        private TimeSpan    tijd;
    }

    */

    //1st place :  5 pts
    //2st place :  4 pts
    //3st place :  3 pts
    //4st place+   2 pts







}
