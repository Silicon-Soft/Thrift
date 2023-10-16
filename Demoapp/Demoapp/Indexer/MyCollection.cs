/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoapp.Indexer
{
    internal class MyCollection
    {
        private string one;
        private string two; 
        private string three;
        private string four;
        private string five;
        public string this[int idx]
        {
            set 
            {
                switch(idx)
                {
                    case 1: 
                        one = value;
                        break;
                    case 2:
                        two = value;
                        break;
                    case 3:
                        three = value;
                        break;
                    case 4:
                        four = value;
                        break;
                    case 5:
                        five = value;
                        break;
                    default:
                        Console.WriteLine("Invalid index");
                        break;

                }

            }
            get
            {
                switch (idx)
                {
                        case 1: return one;
                        case 2: return two;
                        case 3: return three;
                        case 4: return four;
                        case 5: return five;
                        default:
                        Console.WriteLine("Invalid index");
                        return "";
                        
                }    
            }
        }
    }
}
*/