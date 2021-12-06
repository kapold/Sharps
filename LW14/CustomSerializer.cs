using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace LW14
{
    public class CustomSerializer
    {
        public static string path = 
            Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW14\LW14\");
        
        // Файлы разных типов
        public static FileStream BinStream()
        {
            string filePath = Path.GetFullPath(path + @"info.bin");
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            return fs;
        }
        
        public static FileStream JsonStream()
        {
            string filePath = Path.GetFullPath(path + @"info.json");
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            return fs;
        }
        
        public static FileStream XmlStream()
        {
            string filePath = Path.GetFullPath(path + @"info.xml");
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            return fs;
        }
        
        // Сериализация и десериализация в .bin
        public static void SerializeBinary(object obj)
        {
            FileStream fs = BinStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, obj);
            fs.Close();
        }

        public static void DeserializeBinary()
        {
            FileStream fs = BinStream();
            BinaryFormatter formatter = new BinaryFormatter();
            Sapper newSapper = (Sapper) formatter.Deserialize(fs);
            Console.WriteLine("\n<---------  BINARY Serialized  --------->");
            Console.WriteLine($"Object: {newSapper.developer}, {newSapper.name}, {newSapper.type}");
            fs.Close();
        }
        
        // Сериализация и десериализация в .json
        public static void SerializeJson(Sapper obj)
        {
            FileStream fs = JsonStream();
            JsonSerializer.SerializeAsync(fs, obj);
            fs.Close();
        }

        public static async void DeserializeJson()
        {
            FileStream fs = JsonStream();
            Sapper newSapper = await JsonSerializer.DeserializeAsync<Sapper>(fs);
            Console.WriteLine("\n<---------  JSON Serialized  --------->");
            Console.WriteLine($"Object: {newSapper.developer}, {newSapper.name}, {newSapper.type}");
            fs.Close();
        }
        
        // Сериализация и десериализация в .xml
        public static void SerializeXml(object obj)
        {
            FileStream fs = XmlStream();
            XmlSerializer formatter = new XmlSerializer(typeof(Sapper));
            formatter.Serialize(fs, obj);
            fs.Close();
        }

        public static void DeserializeXml()
        {
            FileStream fs = XmlStream();
            XmlSerializer formatter = new XmlSerializer(typeof(Sapper));
            Sapper newSapper = (Sapper) formatter.Deserialize(fs);
            Console.WriteLine("\n<---------  XML Serialized  --------->");
            Console.WriteLine($"Object: {newSapper.developer}, {newSapper.name}, {newSapper.type}");
            fs.Close();
        }
        
        
        // Serialize All
        public static void SerializeAll(Sapper obj)
        {
            SerializeBinary(obj);
            DeserializeBinary();
            SerializeJson(obj);
            DeserializeJson();
            SerializeXml(obj);
            DeserializeXml();
        }
        
    }
}