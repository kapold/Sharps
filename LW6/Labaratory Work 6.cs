using System;
using System.Collections.Generic;
using System.Linq;

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
        interface ISetOfOperations
        {
            void info();
        } // Интерфейс

        public partial class Developer
        {
            public string developer { set; get; }
            
            public override string ToString()
            {
                return $"Dev: {developer}";
            }
        }
        
        public abstract class Software : Developer
        {
            public string name { set; get; }
            public string type { set; get; }
            public string developer { set; get; }
            public string version { set; get; }
            
            public override string ToString()
            {
                return $"Software: {name}, {type}, {developer}";
            }
            
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
            public void Developer()
            {
                Console.WriteLine($"Разработчик сапера: {developer} \n");
            }
            
            public void info()
            {
                Console.WriteLine("<- Game is Sapper ->");
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

            // Композиция
            Preview pr;
            public Sapper()
            {
                this.pr = new Preview("Hello");
            }
            
            
        }

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
        
        
        
        
        // ЛР6
        enum Enumerable : byte
        {
            Developer,
            Software,
            WordProcessor,
            Word
        } // Перечисление

        struct Person
        {
            public string name { set; get; }
            public float age { set; get; }
            public Person(string name,int age)
            {
                this.age = age;
                this.name = name;
            }
            public void About()
            {
                Console.WriteLine($"Name is {name} and Age is {age}");
            }
        } // Структура

        class Computer
        {
            public List<Software> container { set; get; }
            public Computer()
            {
                container = new List<Software>();
                return;
            }

            public Software this[int index]
            {
                get { return container[index]; }
                set { container[index] = value; }
            }

            public void AddItem(Software s) => container.Add(s);
            public void DeleteItem(Software s) => container.Remove(s);

            public void Print()
            {
                Console.WriteLine("Items of Container: ");
                for (int i = 0; i < container.Count; i++)
                {
                    Console.WriteLine("   " + container[i].name);
                }
            }
            
            
        } // Класс-Контейнер

        public static class Controller
        {
            public static void FindCurrentGameType(List<Software> g)
            {
                string CType = "Puzzle";
                for (int i = 0; i < g.Count; i++)
                {
                    if (g[i].type == CType)
                    {
                        Console.WriteLine("Current Game - " + g[i]);
                    }
                }
            }

            public static void FindVersionEditor(List<Software> g)
            {
                string ver = "1.2";
                for (int i = 0; i < g.Count; i++)
                {
                    if (g[i].version == ver)
                    {
                        Console.WriteLine($"Editor with version {ver} - " + g[i]);
                    }
                }
            }

            public static void SortedSoftware(List<Software> g)
            {
                Software temp;
                Console.WriteLine("Sorted List: ");
                var sortedSoftware = g.OrderBy(u => u.name);
                foreach (var softw in sortedSoftware)
                {
                    Console.WriteLine("   " + softw.name);
                }
            }

            /*public static void FileOutput(List<Software> g)
            {
                string path = @"D:\Универ 2 курс\Университет 3 семестр\ООП\LW6\LW6";
                using (FileStream fstream = File.OpenRead($"{path}/file.txt"))
                {

                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    string[] readText = File.ReadAllLines(path);
                    Console.WriteLine(readText[0] + readText[1]);
                    g[4].name = System.Text.Encoding.Default.GetString(array);
                    
                    //g.Add(new Game(){ name = , type = , developer = });
                    Console.WriteLine("   " + g[4].name);
                    Console.WriteLine("   " + g[4].type);
                    Console.WriteLine("   " + g[4].developer);
                }

                Console.ReadLine();
            }*/
        } // Класс-контроллер

        static void Main(string[] args)
        {
            /*CConficker conf = new CConficker { name = "Net-Worm.Win32.Kido.bt", type = "Computer worm" };
            conf.Name();
            conf.Type();
            Sapper sapper = new Sapper { name = "Sapper", type = "Game", developer = "Microsoft" };
            sapper.Name();
            sapper.Type();
            sapper.Developer();
            Word word = new Word { name = "Word", type = "Program", developer = "Microsoft"};
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
            ((IInterface2)interf).Method1();*/
            
            // ЛР 6
            Enumerable a;
            a = Enumerable.Word;
            Console.WriteLine("Enum item: " + a);
            Console.WriteLine("Enum item(number): " + (int)a);

            Person man = new Person("Alex", 18);
            man.About();

            Computer PC = new Computer();
            Game sapper1 = new Game { name = "TheWitcher", type = "RPG", developer = "CDProject" };
            Word word1 = new Word { name = "MSWord", type = "Word", developer = "Microsoft" , version = "1.2" };
            Sapper sapper2 = new Sapper { name = "Sapper", type = "Puzzle", developer = "Someone" };
            Word word2 = new Word { name = "WPS", type = "Word", developer = "Arb" , version = "1.1" };
            PC.AddItem(sapper1);
            PC.AddItem(word1);
            PC.AddItem(sapper2);
            PC.AddItem(word2);
            PC.Print();
            
            Controller.FindCurrentGameType(PC.container);
            Controller.FindVersionEditor(PC.container);
            Controller.SortedSoftware(PC.container);

            // Game test = new Game();
            // PC.AddItem(test);
            // Controller.FileOutput(PC.container);
        }
    }
}

    /*
      Собрать (установить) разное ПО на Компьютер (хранить в виде списка или массива).
      Найти Игрушки определенного типа и текстовый редактор
      заданной версии, вывести все ПО в алфавитном порядке.
    */