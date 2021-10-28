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
            private string Naming = "No";
            public string name
            {
                get
                {
                    return Naming;
                }
                set
                {
                    Debug.Assert(value == "");

                    try
                    {
                        if (value == null)
                        {
                            throw new Exceptions.NoVirus("You should name your virus");
                        }
                        if (value == "")
                        {
                            throw new Exceptions.NoVirus("You should name your virus");
                        }
                    }
                    catch (Exceptions.NoVirus e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            private int Quantity = 0;
            public int quantity
            {
                get
                {
                    return Quantity;
                }
                set
                {
                    try
                    {
                        if (value < 0)
                        {
                            throw new Exceptions.NumberException("Incorrect number");
                        }
                        else if (value == 0)
                        {
                            throw new Exceptions.IsZero("Number is Zero");
                        }
                        else quantity = value;
                    }
                    catch (Exceptions.IsZero e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }
                    catch (Exceptions.NumberException e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }
                }
            }
            
            
            public void Name()
            {
                Console.WriteLine($"Название вируса: {name}");
            }
            public void Type()
            {
                Console.WriteLine($"Тип вируса: {quantity}");
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
                return $"CConficker: {name}, {quantity}";
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


        // 7
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
            //  1
            CConficker conf = new CConficker();
            try
            {
                conf.name = "Corona";
                conf.quantity = -9;
            }
            catch (Exceptions.NoVirus e)
            {
                Console.WriteLine("Экземпляр создан неправильно: " + e);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.TargetSite);
            }
            
            // 2
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
            // 3
            try
            {
                ForErrors error = new ForErrors(-1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            // 4
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
            // 5.
            try
            {
                string abc = null;
            }
            catch (Exceptions.StringException e)
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
            finally
            {
                Console.WriteLine("Ошибки кончились");
            }
        }
    }
}