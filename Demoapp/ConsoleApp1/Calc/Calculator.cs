using Interface.Add;
using Interface.Attibutes;
using Interface.Subtractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Calc
{
   // [Author("Samikshya")]
    public class Calculator : IAdder, ISubtractor
    {
        //[Author("Samikshya")]
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}