using System;
using System.Xml.Serialization;

namespace LW14
{
        [Serializable]
        public class Developer
        {
            public string developer { set; get; }
            
            public override string ToString()
            {
                return $"Dev: {developer}";
            }
        }
        
        [Serializable]
        public abstract class Software : Developer
        {
            public string name { set; get; }
            public string type { set; get; }
            public string developer { set; get; }
            
            public override string ToString()
            {
                return $"Software: {name}, {type}, {developer}";
            }

            public abstract void NewMethod();

        } // Абстрактный класс
        
        [Serializable]
        public class Game : Software
        {
            public string developer { set; get; }
            
            public void Developer()
            {
                Console.WriteLine($"Разработчик сапера: {developer} \n");
            }
            
            public void info()
            {
                Console.WriteLine("<- Game is Sapper ->");
            }

            public override void NewMethod()
            {
                Console.WriteLine("Abstr meth");
            }
        }
        
        [Serializable]
        public class Sapper : Game
        {
            [NonSerialized]
            [XmlIgnore]
            public string NonSerializable = "NonSer";
            
            public void Name()
            {
                Console.WriteLine($"Название сапера: {name}");
            }
            public void Type()
            {
                Console.WriteLine($"Тип сапера: {type}");
            }
            public override string ToString()
            {
                return $"Sapper: {name}, {type}, {developer}";
            }

            
            Preview pr;
            public Sapper()
            {
                this.pr = new Preview("Hello");
            }
        } // Композиция

        [Serializable]
        class Preview
        {
            public string prev;
            public Preview(string p)
            {
                prev = p;
            }
        } // Композиция
}