using Demoapp.Indexer;
using Demoapp.Indexer.Sealed;
using Demoapp.Part;
using System;
using System.Security.Cryptography.X509Certificates;
using Demoapp.Virtual;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Demoapp
{
/*    public struct Number
    {*/
        /*public int Numerator;
        public int Denominator;
        public decimal value
        {
            get
            {
                return Numerator/Denominator;
            }
        }*/


        class Program
        {
            /* public static async Task Main(string[] args)
             {
                *//* Console.WriteLine("Processing Order");
                 var email = SendEmail();
                 Console.WriteLine("Processing Completed!!!");
                 Console.WriteLine("Waiting for email to be sent");
                 await email;
                 Console.WriteLine("All done");*//*

             }*/
            //threading
            public static void Main(string[] args)//async Task SendEmail()
            {
                /* Func<int, int, int> A1 = (x, y) => x+y;//expression lambda
                 Func<int, int, int> A2 = (x, y) =>//statement lambda
                 {
                     return x+y;
                 };
                 List<int> l = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                 List<int> f = l.Where(x => x > 5).ToList();
                 foreach (int i in f)
                 {
                     Console.WriteLine(i);

                 }*/
                /*Console.WriteLine("Sending email");
                await Task.Delay(5000);
                Console.WriteLine("Email sent........");*/

                //enum ko ho hei
                /*      Days D = Days.Tuesday;
                      Console.WriteLine("value of " + D + " is"+(int)D);

                      Status S = Status.Inactive;
                      Console.WriteLine("value of" + S +" is "+(int)S);*/


                /*   //struct
                   Number N;
                   N.Numerator =10;
                   N.Denominator =5;
                   Console.WriteLine(N.value);*/
                /*

                                Console.WriteLine("Using LINQ");
                                List<int> L = new List<int> { 1, 2, 3, 4, 5 };
                                List<int> f = (from l in L
                                               where l<5
                                               select l).ToList();
                                foreach (int i in f)
                                {
                                    Console.WriteLine(i);

                                }*/
                Console.WriteLine("Area of Rectangle: 400"); 

            }
       }
    


    
}











