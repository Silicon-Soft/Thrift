using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates1.Events
{
    internal class OrderProcessor
    {
        public delegate void OrderProcessedHandler(object source, EventArgs e);//define event
        public event OrderProcessedHandler OrderProcessed;//define event based on deligate
        public void Process(Order O)
        {
            /*   EmailService EmailService = new EmailService();  */
            Console.WriteLine("...Processing Order...");
            //TO DO: logic
            Console.WriteLine("...Processing Completed...");
            OnOrderProcessed();
        }
           /* EmailService.SendEmail(O);//jasle order garyo teskei email address ma email garne
        }*/
        protected virtual void OnOrderProcessed()
        {
            if (OrderProcessed!= null)
                OrderProcessed(this, EventArgs.Empty);//event raise huncha yha
        }
    }
}
