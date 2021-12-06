using System;
using System.IO;
using System.Xml;

namespace LW14
{
    public class PathSerial
    {
        public static void XPath()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Path.GetFullPath(CustomSerializer.path + @"info.xml"));
            XmlElement xRoot = xDoc.DocumentElement;
            
            Console.WriteLine($"\n<---------  XPath  --------->");
            Console.WriteLine("\nAll nodes: ");
            XmlNodeList childNodes = xRoot.SelectNodes("*");
            foreach (XmlNode node in childNodes)
            {
                Console.WriteLine(node.OuterXml);
            }
            
            Console.WriteLine("\nAll <name> nodes: ");
            XmlNodeList nameNodes = xRoot.SelectNodes("//Sapper/name");
            foreach (XmlNode name in nameNodes)
            {
                Console.WriteLine(name.InnerText);
            }
        }
    }
}