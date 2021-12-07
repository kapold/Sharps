using System;

namespace LW12
{
        // <---- Одноименные методы ---->
        interface IInterface1{
            void Method1();
        }
        interface IInterface2{
            void Method1();
        }
        
        class SomeClass : IInterface2, IInterface1
        {
            void IInterface1.Method1(){
                Console.WriteLine("Interface1");
            }
            void IInterface2.Method1(){
                Console.WriteLine("Interface2");
            }
        }
        // <----------------------------->

        interface ISetOfOperations
        {
            void info();

            static void Hello()
            {
                Console.WriteLine("Hi");
            }
            static int MaxNumber = 9;
            const int MinNumber = 0;
        } // Интерфейс
        
        class Developer
        {
            public string developer { set; get; }
            
            public override string ToString()
            {
                return $"Dev: {developer}";
            }
        }
        
        abstract class Software : Developer
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
        
        // 1st (Developer -> Virus -> CConficker)
        class Virus : Developer
        {
            public string name { set; get; }
            public string type { set; get; }
            public void Name()
            {
                Console.WriteLine($"Название вируса: {name}");
            }
            public void Type()
            {
                Console.WriteLine($"Тип вируса: {type}");
            }
        }
        sealed class CConficker : Virus, ISetOfOperations
        {
            public void info()
            {
                Console.WriteLine($"Description: {developer}");
            }

            public override string ToString()
            {
                return $"CConficker: {name}, {type}";
            }
            
        }
        
        // 2nd (Developer -> ПО -> Game -> Sapper)
        class Game : Software, ISetOfOperations
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
        class Sapper : Game
        {
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

        class Preview
        {
            public string prev;
            public Preview(string p)
            {
                prev = p;
            }
        } // Композиция
        
        // 3d (Developer -> ПО -> WordProcessor -> Word)
        class WordProcessor : Software, ISetOfOperations
        {
            public string developer { set; get; }
            
            public void Developer()
            {
                Console.WriteLine($"Разработчик: {developer} \n");
            }
            
            public void info()
            {
                Console.WriteLine("<- WordProcessor is Word ->");
            }
            
            public override void NewMethod()
            {
                Console.WriteLine("Abstr meth2");
            }
        }

        class Word : WordProcessor
        {
            public void Name()
            {
                Console.WriteLine($"Название: {name}");
            }
            public void Type()
            {
                Console.WriteLine($"Тип: {type}");
            }
            public override string ToString()
            {
                return $"Word: {name}, {type}, {developer}";
            }

            public Word(string Name, string Type, string Developer)
            {
                name = Name;
                type = Type;
                developer = Developer;
            }

            public Word()
            {
                name = "idk";
                type = "unknown";
                developer = "???";
            }
            
            public void LW12Method(string name, string type)
            {
                Console.WriteLine($"Название: {name}; Тип: {type}");
            }
        }
        
        // Printer
        class Printer : APrinter
        {
            public string IAmPrinting;
        }
        abstract class APrinter
        {
            public void IamPrinting(Developer someobj)
            {
                Console.WriteLine($"Тип этого обьекта: " + someobj.GetType());
                Console.WriteLine(someobj.ToString());
            }
        }
        // <------------------------>

        
        class Over
        {
            public string name { get; set; } = "Overriding";
            
            public Over(string fame)
            {
                this.name = fame;
            }

            public override int GetHashCode()
            {
                Console.WriteLine($"\nHash of {this.name} is: {name.GetHashCode()}\n");
                return name.GetHashCode();
            }
            
            public override string ToString()
            {
                return $"{name}\n";
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                Over el = obj as Over;
                if (el as Over == null)
                    return false;

                return el.name == this.name;
            }
        }
}