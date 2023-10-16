/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoapp.Virtual
{
    internal  class Teacher : Person
    {
        public override void DisplayInfo() { }
        public int TeacherID { get; set; }
        public Teacher(String name, string email, string phone, int teacherID) : base(name, email, phone)

        {
            TeacherID=teacherID;
        }
        public void Display()
        {
            Console.WriteLine("Teacher"); 
            base.DisplayInfo();
        }
    }
}
*/