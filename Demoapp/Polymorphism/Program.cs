using System;
using Polymorphism.Overloading;
namespace Polymorphism
{
    public class Program
    {
        public static void Main(string[] args)
        {



            /*Calculator calc = new Calculator(20, -55);

            calc = -calc;

            // To display the result
            calc.Print();*/
                        //


                        /* Rectangle R1 = new Rectangle
                         {
                             length=10,
                             breadth=7
                         };
                         Rectangle R2 = new Rectangle
                         {
                             length=20,
                             breadth=4
                         };
                         *//*Rectangle R = R1+R2;*//*
                         Console.WriteLine("Addition of two Rectangle is:"+ R1+R2);*/
                        /*          int resultInt = Operation.Add(1, 2);
                                  resultInt=Operation.Add(1, 2);

                                  decimal resultdecimal = Operation.Add(1, 2, 3);
                                  resultInt=Operation.Add(1, 2,4);
                     */

                Console.WriteLine("Addition of two no:"+Operation.Add(1, 2));
                Console.WriteLine("Addition of three no:"+Operation.Add(8, 9, 5));
                Console.WriteLine("Addition of four no:"+Operation.Add(1, 2, 7, 8));
        }
    }
}

