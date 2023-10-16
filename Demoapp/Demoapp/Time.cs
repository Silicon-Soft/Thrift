using System;

namespace Demoapp
{
    public class Time
    {
        public decimal Seconds { get; set; }
        public Time() //default constructor
        {
            Seconds=20;



        }
        public Time(decimal seconds) //parameterised constructor
        {
            Seconds = seconds;
            Console.WriteLine("The seconds:",Seconds);

        }
        public decimal display()
        {
            return Seconds;
        }




    }
}


