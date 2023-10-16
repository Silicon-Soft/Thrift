using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Overloading
{
    internal class Operation
    {
        public static int Add(int a,int b)
        { return a + b; }   
        public static int Add(int a,int b, int c)
        {
            return a + b + c;
        }
        public static int Add(int a, int b, int c, int d)
        {
            return a + b + c + d;
        }

    }
}
