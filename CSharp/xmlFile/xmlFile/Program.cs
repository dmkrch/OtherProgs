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
                foreach (XmlNode studentFieldNode in studentNode.ChildNodes)
                {
                    // if node - age
                    if (studentFieldNode.Name == "age")
                    {
                        Console.WriteLine($"Age: {studentFieldNode.InnerText}");
                    }
                    // if node - group
                    if (studentFieldNode.Name == "group")
                    {
                        XmlNode groupAttr = studentFieldNode.Attributes.GetNamedItem("name");
                        if (groupAttr != null)
                            Console.WriteLine(groupAttr.Value);

                        // bypassing all the child nodes of <group>
                        foreach (XmlNode groupFieldNode in studentFieldNode.ChildNodes)
                        {
                            if (groupFieldNode.Name == "number")
                            {
                                Console.WriteLine($"Number of group: {groupFieldNode.InnerText}");
                            }
                        }
                    }
                }
                Console.WriteLine();
            }





            /* adding object to xml file */
            XmlDocument xDoc1 = new XmlDocument();
            xDoc1.Load(@"D:\Programming\Other\CSharp\xmlFile\xmlFile\data.xml");
            XmlElement xRoot1 = xDoc1.DocumentElement;

            // создаем новый элемент student
            XmlElement studentElem = xDoc1.CreateElement("student");

            // создаем атрибут name и текст аттрибута
            XmlAttribute studentAttr = xDoc1.CreateAttribute("name");
            XmlText studentAttrText = xDoc1.CreateTextNode("Vasya Pupkin");

            // создаем элемент age
            XmlElement ageElem = xDoc1.CreateElement("age");
            XmlText ageText = xDoc1.CreateTextNode("20");


            //создаем элемент группа
            XmlElement groupElem = xDoc1.CreateElement("group");
      
            // создаем атрибут name группы и текст аттрибута
            XmlAttribute groupAttr1 = xDoc1.CreateAttribute("name");
            XmlText groupAttrText = xDoc1.CreateTextNode("amazing group");

            // создаем элемент номер группы
            XmlElement groupNumber = xDoc1.CreateElement("number");
            XmlText groupNumberText = xDoc1.CreateTextNode("953500");

            // собираем группу
            groupAttr1.AppendChild(groupAttrText);       // вставляем текст атрибута в атрибут
            groupElem.Attributes.Append(groupAttr1);     // вставляем атрибут в группу
            groupNumber.AppendChild(groupNumberText);   // вставляем текст номера группы в номер группы
            groupElem.AppendChild(groupNumber);         // вставляем номер группы в группу  

            // собираем студента 
            studentAttr.AppendChild(studentAttrText);   // вставляем текст атрибута в атрибут
            studentElem.Attributes.Append(studentAttr); // вставляем атрибут в студента
            ageElem.AppendChild(ageText);               // вставляем текст возраста в возраст
            studentElem.AppendChild(ageElem);           // вставляем возраст в студента
            studentElem.AppendChild(groupElem);         // вставляем группу в студента


            xRoot1.AppendChild(studentElem);
            xDoc1.Save(@"D:\Programming\Other\CSharp\xmlFile\xmlFile\data.xml");
        }
    }
}
