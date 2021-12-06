using System;
using System.Xml.Linq;

namespace LW14
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Сериализация и десериализация форматов bin,
            // json и xml.
            Sapper sapper = new Sapper { name = "Sapper", type = "Game", developer = "Microsoft" };
            Console.WriteLine("Serializing: ");
            CustomSerializer.SerializeAll(sapper);
            
            // Task 2: Создайте коллекцию (массив) объектов и выполните
            // сериализацию/десериализацию.
            Sapper sap1 = new Sapper { name = "Sap1", type = "Game", developer = "Microsoft" };
            Sapper sap2 = new Sapper { name = "Sap2", type = "Program", developer = "JetBrains" };
            Sapper[] sappers =
            {
                sap1, sap2
            };
            foreach (var sap in sappers)
            {
                CustomSerializer.SerializeBinary(sap);
                CustomSerializer.DeserializeBinary();
            }
            
            // Task 3: Используя XPath напишите два селектора
            // для вашего XML документа.
            PathSerial.XPath();
            
            // Task 4: Используя Linq to XML (или Linq to JSON) создайте новый xml (json) -
            // документ и напишите несколько запросов.
            XDocument xDoc = LINQToXml.CreateXml();
            LINQToXml.PrintCarsXml(xDoc);
            LINQToXml.LinqXml(xDoc);
            
        }
    }
}