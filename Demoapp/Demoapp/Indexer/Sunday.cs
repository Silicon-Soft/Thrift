using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoapp.Indexer
{
    internal class Sunday
    {
       
        public int this[string idx]
        {
          
            get
            {
                switch (idx)
                {
                    case "Sunday": return 1;
                    case "Monday": return 2;
                    case "Tuesday": return 3;
                    case "Wednesday": return 4;
                    case "Friday": return 6;
                    case "Saturday": return 7;
                    default: return 0;
                
                        

                }
            }
        }
    }
}
