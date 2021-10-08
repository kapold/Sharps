using System;
    /*
      ПО, Набор операций, Текстовый процессор, Word, Вирус,
      CConficker Игрушка, Сапер, Разработчик.
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

        interface IProgrammer
        {
            void Name();
            void Type();
            void Developer();
        }

        abstract class AYear
        {
            public string year { set; get; }
            public virtual void Name() {}
        }
        sealed class Software : AYear, IProgrammer
        {
            public string name { set; get; }
            public string type { set; get; }
            public string developer { set; get; }

            public void Name()
            {
                Console.WriteLine($"Название ПО: {name}");
            }
            public void Type()
            {
                Console.WriteLine($"Тип ПО: {type}");
            }
            public void Developer()
            {
                Console.WriteLine($"Разработчик ПО: {developer} \n");
            }
            
            public override string ToString()
            {
                return $"Software: {name}, {type}, {developer}";
            }
        }
        
        sealed class WordProcessor : AYear, IProgrammer
        {
            public string name { set; get; }
            public string type { set; get; }
            public string developer { set; get; }

            public void Name()
            {
                Console.WriteLine($"Название редактора: {name}");
            }
            public void Type()
            {
                Console.WriteLine($"Тип редактора: {type}");
            }
            public void Developer()
            {
                Console.WriteLine($"Разработчик редактора: {developer} \n");
            }
            
            public override string ToString()
            {
                return $"WordProcessor: {name}, {type}, {developer}";
            }
        }
        
        sealed class Virus : AYear, IProgrammer
        {
            public string name { set; get; }
            public string type { set; get; }
            public string developer { set; get; }
            
            public void Name()
            {
                Console.WriteLine($"Название вируса: {name}");
            }
            public void Type()
            {
                Console.WriteLine($"Тип вируса: {type}");
            }
            public void Developer()
            {
                Console.WriteLine($"Разработчик вируса: {developer} \n");
            }
            
            public override string ToString()
            {
                return $"Virus: {name}, {type}, {developer}";
            }
        }
        
        sealed class Sapper : AYear, IProgrammer
        {
            public string name { set; get; }
            public string type { set; get; }
            public string developer { set; get; }
            
            public void Name()
            {
                Console.WriteLine($"Название сапера: {name}");
            }
            public void Type()
            {
                Console.WriteLine($"Тип сапера: {type}");
            }
            public void Developer()
            {
                Console.WriteLine($"Разработчик сапера: {developer} \n");
            }
            
            public override string ToString()
            {
                return $"Sapper: {name}, {type}, {developer}";
            }
        }

        class Printer : APrinter
        {
            public string IAmPrinting;
        }
        abstract class APrinter
        {
            public void IamPrinting(AYear someobj)
            {
                Console.WriteLine($"Тип этого обьекта: " + someobj.GetType());
                Console.WriteLine(someobj.ToString());
            }
        }

        
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
            Software soft = new Software { name = "Hub", type = "Git", developer = "Anton INC."};
            soft.Name();
            soft.Type();
            soft.Developer();
            WordProcessor proc = new WordProcessor { name = "Word", type = "Processor", developer = "Microsoft"};
            proc.Name();
            proc.Type();
            proc.Developer();
            Virus venom = new Virus { name = "Venom", type = "ComputerV", developer = "No Information"};
            venom.Name();
            venom.Type();
            venom.Developer();
            Sapper sapper = new Sapper { name = "Sapper", type = "Game", developer = "Microsoft"};
            sapper.Name();
            sapper.Type();
            sapper.Developer();
            
            Printer print = new Printer();
            print.IamPrinting(soft);
            print.IamPrinting(proc);
            print.IamPrinting(venom);
            print.IamPrinting(sapper);
            
            Virus Vir = venom as Virus;
            if (Vir == null)
            {
              Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
              Console.WriteLine("Преобразование прошло удачно");
            }

            if (soft is Software)
            {
              Software soft2 = (Software)soft;
              Console.WriteLine("Преобразование допустимо");
            }
            else
            {
              Console.WriteLine("Преобразование не допустимо");
            }
            
            dynamic[] array = new dynamic[] {soft, proc, venom, sapper};

            // Одноименные методы
            SomeClass interf = new SomeClass();
            ((IInterface1)interf).Method1();
            ((IInterface2)interf).Method1();
        }
    }
}