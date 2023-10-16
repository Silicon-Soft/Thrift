using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Demoapp.Inheritance
{
    internal class Rectangle : Shape
    {
        public void Area()
        {
            int area = length*breadth;
            Console.WriteLine("Area of Rectangle="+area);

        }
        public  void Perimeter()
        {
            int Perimeter = 2*(length+breadth);
            Console.WriteLine("Perimetre of Rectangle="+Perimeter);

        }

    }
}
