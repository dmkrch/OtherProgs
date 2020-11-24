using System;
using System.Collections.Generic;
using System.Xml;

namespace xmlFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Group group1 = new Group(953504, "amazing group");
            Group group2 = new Group(953501, "poor group");

            Student st1 = new Student("Vasya", 18, group1);
            Student st2 = new Student("Dima", 19, group1);
            Student st3 = new Student("Anton", 20, group2);

            List<Student> students = new List<Student>();

            students.Add(st1);
            students.Add(st2);
            students.Add(st3);


            List<Student> students1 = new List<Student>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"D:\Programming\Other\CSharp\xmlFile\xmlFile\data.xml");

            // getting root element
            XmlElement xRoot = xDoc.DocumentElement;

            // bypassing all nodes in root element
            // node is actually one student 

            foreach (XmlNode studentNode in xRoot)
            {
                // getting attribute name
                if (studentNode.Attributes.Count > 0)
                {
                    XmlNode attr = studentNode.Attributes.GetNamedItem("name");
                    if (attr != null)
                        Console.WriteLine(attr.Value);
                }
                // bypassing all the child nodes of <student>
                foreach (XmlNode studentNodeField in studentNode.ChildNodes)
                {
                    // if node - age
                    if (studentNodeField.Name == "age")
                    {
                        Console.WriteLine($"Age: {studentNodeField.InnerText}");
                    }
                    // if node - group
                    if (studentNodeField.Name == "group")
                    {
                        /* here is for group */
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
