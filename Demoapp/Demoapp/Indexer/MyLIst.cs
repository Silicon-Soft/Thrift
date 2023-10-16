/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoapp.Indexer
{
    //generic class are parameterized data type
    internal class MyLIst<T>
    {
        private T[] _arr;
        public MyLIst(int size)
        {
            _arr = new T[size];//parameterized  constructor
        }
        
        public T this[int idx] 
        {
        
            get { 
                return _arr[idx];
            }
            set
            {
                 _arr[idx] = value;  
            }
        }

    }
}
*/