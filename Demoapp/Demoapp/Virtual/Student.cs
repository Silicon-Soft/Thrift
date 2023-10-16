/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoapp.Virtual
{
    internal class Student : Person
    {
        public Student(string name, string email, string phone) : base(name, email, phone)
        {
        }

         public override void DisplayInfo()//override ma body same linch avane method hiding ma chei sabbei change 
        {

         }
        public int StudentID { get; set; }
        public Student(String name, string email, string phone, int studentID) : base(name, email, phone)

        {
            StudentID=studentID;
        }
        public void Display()
        {
            Console.WriteLine("Student"); 
            base.DisplayInfo();
        }
    }
}
*/