using System;
using System.Collections.Generic;
using System.Text;

namespace xmlFile
{
    public class Student
    {
        public string Name { get; }
        
        public int Age { get; }

        public Group Group { get; set; }

        public Student(string name, int age, Group group)
        {
            Name = name;
            Age = age;
            Group = group;
        }
    }
}
