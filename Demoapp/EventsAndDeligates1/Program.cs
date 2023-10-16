using EventsAndDelegates1.Events;
using EventsAndDeligates1.Delegates;
using System;

namespace EventsAndDelegates1
{
    internal class Program
    {
      /*  public static int Id { get; private set; }
        public static string CustomerName { get; private set; }
        public static int Total { get; private set; }*/

       // public delegate void MyDel(int x, int y);
        static void Main(string[] args)
        {

            //multicast and unicast
            /*Addition A = new Addition();
            MyDel D = new MyDel(A.Add);
            D=D+A.Sub;//A+ le sub lai add garcha vane A- le hataucha kaslai vanye sub lai
            D(3,4);*/

            /* MyDel D = (x, y) =>
             {
                 Console.WriteLine(x+y);
             };
             D(1, 6);*/

            /*  Action<int, int> A = (x, y) =>
              {
                  Console.WriteLine(x/y);
              };
              A(4, 2);*/

            /* Func<string, string, string> A = (x, y) =>//last ko int chei retuen type ho as func le return type denei parcha
             {
                 return x+y;
             };
             string result = A("pratima", "pandey");
             Console.WriteLine(result);*/

          /*  Predicate<int> A = (x) =>//func nei ho but boolean ko lagi use huncha 
            {
                if (x>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                return true;
            };
            bool result = A(0);

            Console.WriteLine(result);
*/
            /*Order O = new Order
            {
                Id=1,
                CustomerName="John",
                Total= 5000
            };
            EmailService EmailService = new EmailService();
            OrderProcessor op = new OrderProcessor();
            op.OrderProcessed += EmailService.SendEmail;
            op.Process(O);*/

        }
    }
}