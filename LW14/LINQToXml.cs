using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace LW14
{
    public class LINQToXml
    {
        public static XDocument CreateXml()
        {
            XDocument xDoc = new XDocument(new XElement("cars",
                new XElement("car",
                    new XAttribute("name", "Mercedes CLS"),
                    new XElement("company", "Mercedes"),
                    new XElement("price", "39.950$")),
                new XElement("car", 
                    new XAttribute("name", "Audi A8"),
                    new XElement("company", "Audi"),
                    new XElement("price", "135.056$"))
            ));

            xDoc.Save(Path.GetFullPath(CustomSerializer.path + @"cars.xml"));
            return xDoc;
        }

        public static void PrintCarsXml(XDocument xDoc)
        {
            Console.WriteLine("\n<---------  XML Cars  --------->");
            foreach (XElement elem in xDoc.Element("cars").Elements("car"))
            {
                XAttribute nameAttribute = elem.Attribute("name");
                XElement companyElement = elem.Element("company");
                XElement priceElement = elem.Element("price");

                if (nameAttribute != null && companyElement != null && priceElement != null)
                {
                    Console.WriteLine($"Машина: {nameAttribute.Value}");
                    Console.WriteLine($"Компания: {companyElement.Value}");
                    Console.WriteLine($"Цена: {priceElement.Value}");
                }
                Console.WriteLine();
            }
        }

        public static void LinqXml(XDocument xDoc)
        {
            Console.WriteLine("\n<---------  LINQ To XML  --------->");
            var carsCompany = from c in xDoc.Element("cars").Elements("car")
                where c.Element("company").Value == "Audi"
                select new Car
                {
                    Name = c.Attribute("name").Value,
                    Price = c.Element("price").Value
                };
            Console.WriteLine("\nCars made by Audi: ");
            foreach (var car in carsCompany)
            {
                Console.WriteLine($"{car.Name} - {car.Price}");
            }
            
            var carsPrice = from c in xDoc.Element("cars").Elements("car")
                where c.Element("price").Value == "39.950$"
                select new Car
                {
                    Name = c.Attribute("name").Value,
                    Price = c.Element("price").Value
                };
            Console.WriteLine("\nCars with price 39.950$: ");
            foreach (var car in carsPrice)
            {
                Console.WriteLine($"{car.Name} - {car.Price}");
            }
        }
        
        
        
        public class Car
        {
            public string Name { get; set; }
            public string Company { get; set; }
            public string Price { get; set; }
        }
    }
}