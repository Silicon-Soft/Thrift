using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoapp.Inheritance
{
    internal class Square : Shape
    {


        public void Area()
        {
            int area = length*length;
            Console.WriteLine("Area of square="+area);

        }
        public void Perimeter()
        {
            int Perimeter = 4*length;
            Console.WriteLine("Perimetre of Square="+Perimeter);

        }


    }
}
