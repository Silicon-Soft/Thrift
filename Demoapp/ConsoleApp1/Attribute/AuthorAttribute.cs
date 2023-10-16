using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Attibutes
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    internal class AuthorAttribute : Attribute
    {
        private string _author;


        public AuthorAttribute(String author)
        {
            _author = author;
        }
    }
}
