using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAppB
{
    public class Student
    {
        public string Number { get; private set; }
        public string Name { get; private set; }
        public string Course { get; private set; }
        public bool Subscribed { get; set; }

        public Student(string number, string name, string course)
        {
            Number = number;
            Name = name;
            Course = course;
            Subscribed = false;
        }
    }
}
