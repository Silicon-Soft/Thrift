using System;
namespace Demoapp
{
    public class Distance
    {
        private decimal _centimeter;

        public decimal Centimeter
        {
            get { return _centimeter; }
            set { _centimeter = value; }
        }

        public decimal Meter
        {
            get { return _centimeter / 100; }
            set { _centimeter = value * 100; }
        }
        public decimal KiloMeter
        {
            get { return Meter / 1000; }
            set { Meter = value * 1000; }
        }

    }
}

