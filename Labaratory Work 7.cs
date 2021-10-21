using System;
using System.Diagnostics;


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

        // ЛР7
        public class NumberException : Exception
        {
            public NumberException(string message) : base(message) {}
        }

        public class StringException : Exception
        {
            public StringException(string message) : base(message) {}
        }

        class ClException : Exception
        {
            public ClException(string message) : base(message) {}
        }

        class ForErrors
        {
            public ForErrors(int count)
            {
                if (count < 0)
                {
                    throw new Exception("Отрицательное число");
                }
            }
        }
        
        
        static void Main(string[] args)
        {
            //  1.Проверка на правильность создания обьекта
            try
            {
                CConficker conf = new CConficker { name = "Net-Worm.Win32.Kido.bt", type = "Computer worm" };
                conf.Name();
                conf.Type();
            }
            catch (ClException e)
            {
                Console.WriteLine("Экземпляр создан неправильно, error: " + e);
                throw;
            }
            
            // 2.Деление на 0
            try
            {
                int a = 0;
                int b = 5 / a;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            // 3.Проверка на отрицательное число
            try
            {
                ForErrors error = new ForErrors(-1);
            }
            catch (NumberException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            // 4.Проверка на строку
            try
            {
                string[] str = new string[1];
                str[1] = "error";
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("Ошибки кончились");
            }
            // 5.
            try
            {
                string abc = null;
            }
            catch (StringException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
            // Универсальный catch
            catch(Exception e)
            {
                Console.WriteLine("Возникла непредвиденная ошибка, описание ошибки:");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.TargetSite);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}