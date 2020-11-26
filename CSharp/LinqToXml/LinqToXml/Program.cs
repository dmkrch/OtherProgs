using System;
using System.Linq;
using System.Xml.Linq;


namespace LinqToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xdoc = XDocument.Load("phones.xml");
            XElement root = xdoc.Element("phones"); 

            foreach (XElement xe in root.Elements("phone").ToList())
            {
                // изменяем название и цену
                if (xe.Attribute("name").Value == "Samsung Galaxy S5")
                {
                    xe.Attribute("name").Value = "Samsung Galaxy Note 4";
                    xe.Element("price").Value = "31000";
                }
                //если iphone - удаляем его
                else if (xe.Attribute("name").Value == "iPhone 6")
                {
                    xe.Remove();
                }
            }
            // добавляем новый элемент
            root.Add(new XElement("phone",
                        new XAttribute("name", "Nokia Lumia 930"),
                        new XElement("company", "Nokia"),
                        new XElement("price", "19500")));
            xdoc.Save("phones.xml");
            // выводим xml-документ на консоль
            Console.WriteLine(xdoc);

            Console.Read();

            /*XElement phone1 = new XElement("phone", new XAttribute("name", "iPhone 6"), new XElement("company", "Apple"), new XElement("price", "40000"));
            XElement phone2 = new XElement("phone", new XAttribute("name", "Samsung Galaxy S5"), new XElement("company", "Samsung"), new XElement("price", "33000"));
            XDocument xdoc = new XDocument(new XElement("phones", phone1, phone2 ));

            xdoc.Save("phones.xml");*/


            // or we can do like that:



            /*
            XDocument xdoc = new XDocument();
            // создаем первый элемент
            XElement iphone6 = new XElement("phone");
            // создаем атрибут
            XAttribute iphoneNameAttr = new XAttribute("name", "iPhone 6");
            XElement iphoneCompanyElem = new XElement("company", "Apple");
            XElement iphonePriceElem = new XElement("price", "40000");
            // добавляем атрибут и элементы в первый элемент
            iphone6.Add(iphoneNameAttr);
            iphone6.Add(iphoneCompanyElem);
            iphone6.Add(iphonePriceElem);

            // создаем второй элемент
            XElement galaxys5 = new XElement("phone");
            XAttribute galaxysNameAttr = new XAttribute("name", "Samsung Galaxy S5");
            XElement galaxysCompanyElem = new XElement("company", "Samsung");
            XElement galaxysPriceElem = new XElement("price", "33000");
            galaxys5.Add(galaxysNameAttr);
            galaxys5.Add(galaxysCompanyElem);
            galaxys5.Add(galaxysPriceElem);
            // создаем корневой элемент
            XElement phones = new XElement("phones");
            // добавляем в корневой элемент
            phones.Add(iphone6);
            phones.Add(galaxys5);
            // добавляем корневой элемент в документ
            xdoc.Add(phones);
            //сохраняем документ
            xdoc.Save("phones.xml");*/
        }
    }
}
