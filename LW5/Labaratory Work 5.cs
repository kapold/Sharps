using System;
    /*
      Разработчик -> Вирус -> CConficker
      Разработчик -> ПО -> Игрушка -> Сапер
      Разработчик -> ПО -> Текстовый редактор -> Word
      Интерфейс: Набор операций
    */

namespace LW5
{
    class Program
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

        static void Main(string[] args)
        {
            CConficker conf = new CConficker { name = "Net-Worm.Win32.Kido.bt", type = "Computer worm" };
            conf.Name();
            conf.Type();
            Sapper sapper = new Sapper { name = "Sapper", type = "Game", developer = "Microsoft" };
            sapper.Name();
            sapper.Type();
            sapper.Developer();
            Word word = new Word { name = "Word", type = "Program", developer = "Microsoft" };
            word.Name();
            word.Type();
            word.Developer();

            Printer print = new Printer();
            print.IamPrinting(conf);
            print.IamPrinting(sapper);
            print.IamPrinting(word);
            
            Virus Vir = conf as CConficker;
            if (Vir == null)
            {
              Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
              Console.WriteLine("Преобразование прошло удачно");
            }

            if (sapper is Sapper)
            { 
                Sapper soft2 = (Sapper)sapper;
              Console.WriteLine("Преобразование допустимо");
            }
            else
            {
              Console.WriteLine("Преобразование не допустимо");
            }
            
            dynamic[] array = new dynamic[] {conf, sapper, word};

            // Одноименные методы
            SomeClass interf = new SomeClass();
            ((IInterface1)interf).Method1();
            ((IInterface2)interf).Method1();
            
            ISetOfOperations.Hello();
        }
    }
}