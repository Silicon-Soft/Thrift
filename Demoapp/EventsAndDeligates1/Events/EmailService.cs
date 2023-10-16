using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates1.Events
{
    internal class EmailService
    {
        public void SendEmail(object source, EventArgs e)//delegate ko parameter ko name milauna ko lagi
        {
            Console.WriteLine("...Sending Email to customer...");
        }
    }
}
