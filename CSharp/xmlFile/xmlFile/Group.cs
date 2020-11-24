using System;
using System.Collections.Generic;
using System.Text;

namespace xmlFile
{
    public class Group
    {
        public int Number { get; set; }

        public string Name { get; set; }

        public Group(int number, string name)
        {
            Number = number;
            Name = name;
        }
    }
}
