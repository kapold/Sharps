using System;
using System.Collections.Generic;

namespace LW4
{
    public class Array
    {
            public int[] array;
            public int n;

            public Array(int[] a, int b)
            {
                array = a;
                n = b;
            }

            public void In()
            {
                Console.Write("Введите элементы массива: ");
                for (int i = 0; i < n; i++)
                {
                    array[i] = int.Parse(Console.ReadLine());
                }
            }

            public void Print()
            {
                Console.Write("Вывод массива: ");
                int count = 0;
                for (int i = 0; i < n; i++)
                {
                    Console.Write(array[i] + " ");
                    count++;
                }
                if (count == 0)
                {
                    Console.WriteLine("Массив пуст");
                }
            }

            public static Array operator *(Array Arr1, Array Arr2)
            {
                Console.WriteLine();
                Console.WriteLine("*");

                var ArrN = new Array(new int[Arr1.n], Arr1.n);
                for (int i = 0; i < Arr1.n; i++)
                {
                    ArrN.array[i] = Arr1.array[i] * Arr2.array[i];
                }
                return ArrN;
            }
            
            public static bool operator !(Array Arr1)
            {
                Console.WriteLine();
                Console.WriteLine("true/false");
                int quantity = 0;
                for (int i = 0; i < Arr1.array.Length - 1; i++)
                {
                    if (Arr1.array[i] < 0)
                    {
                        quantity++;
                    }
                }

                if (quantity > 0)
                    return false;
                else
                    return true;
            }

            public static bool operator ==(Array Arr1, Array Arr2)
            {
                Console.WriteLine();
                Console.WriteLine("==");
                int equals = 0;
                for (int i = 0; i < Arr1.n; i++)
                {
                    if (Arr1.array[i] == Arr2.array[i])
                    {
                        equals++;
                    }
                }

                if (equals == Arr1.n)
                    return true;
                else
                    return false;
            }
            
            public static bool operator !=(Array Arr1, Array Arr2)
            {
                Console.WriteLine();
                Console.WriteLine("==");
                int equals = 0;
                for (int i = 0; i < Arr1.n; i++)
                {
                    if (Arr1.array[i] == Arr2.array[i])
                    {
                        equals++;
                    }
                }

                if (equals != Arr1.n)
                    return true;
                else
                    return false;
            }
            
            public static bool operator >(Array Arr1, Array Arr2 )
            {
                Console.WriteLine();
                Console.WriteLine(">");
                bool b1 = true;
                for (int i = 0; i < Arr1.n; i++)
                {

                    if (Arr1.array[i] > Arr2.array[i]) 
                        b1 = false;

                }
                return b1;
            }
            
            public static bool operator <(Array Arr1, Array Arr2)
            {
                Console.WriteLine();
                Console.WriteLine("<");
                bool b1 = true;
                for (int i = 0; i < Arr1.n; i++)
                {

                    if (Arr1.array[i] > Arr2.array[i]) 
                        b1 = false;

                }
                return b1;
            }

            public int Count()
            {
                return array.Length;
            }
            
        public class Owner
        {
            private int id;
            public int ID { set; get; }
            private string name;
            public string Name { set; get; }
            private string organization;
            public string Organization { set; get; }

            public Owner(int id, string name, string organization)
            {
                ID = id;
                Name = name;
                Organization = organization;
            }
        }
        
        public class Date
        {
            private int day;
            public int Day
            {
                set
                {
                    if (value > 0 && value < 31)
                    {
                        day = value;
                    }
                    else
                    {
                        Console.WriteLine("Error[CheckValue]");
                    }
                }
                get
                {
                    return day;
                }
                
            }
            private int month;
            public int Month
            {
                set
                {
                    if (value > 0 && value < 12)
                    {
                        month = value;
                    }
                    else
                    {
                        Console.WriteLine("Error[CheckValue]");
                    }
                }
                get
                {
                    return month;
                }
                
            }
            private int year;
            public int Year
            {
                set
                {
                    if (value > 0)
                    {
                        year = value;
                    }
                    else
                    {
                        Console.WriteLine("Error[CheckValue]");
                    }
                }
                get
                {
                    return year;
                }
                
            }

            public Date(int day, int month, int year)
            {
                Day = day;
                Month = month;
                Year = year;
            }
        }
    }
    
    public static class StaticOperation
    {
            
        public static Array Sum(Array Arr1, Array Arr2)
        {
            var Arrray = new Array(new int[Arr1.n], Arr1.n);
            for (int i = 0; i < Arr1.n; i++)
            {
                Arrray.array[i] = Arr1.array[i] + Arr2.array[i];
            }
            return Arrray;
        }
            
        public static int MaxMin(Array Arr1)
        {
            int max = Arr1.array[0], min = Arr1.array[0], result = 0;
            for (int i = 0; i < Arr1.array.Length; i++)
            {
                if (max < Arr1.array[i])
                {
                    max = Arr1.array[i];
                }

                if (min > Arr1.array[i])
                {
                    min = Arr1.array[i];
                }
            }
            return result = max - min;
        }
            
        public static int Quantity(Array Arr1)
        {
            int result = Arr1.n;
            return result;
        }

        public static bool CharBool(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }

            if (counter > 0)
            {
                return true;
            }
            else
            {
                return false;
            } 
        }

        public static int[] DeleteArr(this int[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] < 0)
                {
                    mass[i] = 0;
                }
            }
            return mass;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CollectionType<Software> collection = new CollectionType<Software>();

                Software[] soft =
                {
                    new Software("WebStorm"),
                    new Software("PyCharm"),
                    new Software("CLion"),
                    new Software("DataSpell"),
                    new Software("Rider")
                };

                Console.WriteLine("<- Add ->");
                foreach (var s in soft)
                {
                    collection.Add(s);
                }
                Console.WriteLine("Collection: ");
                collection.View();
                
                collection.WriteFile();
                Console.WriteLine("<- Delete ->");
                foreach (var s in soft)
                {
                    collection.Delete(s);
                }
                Console.WriteLine("View after remove: ");
                collection.View();
                
                collection.ReadFile();
                Console.WriteLine("Get information from file and view: ");
                collection.View();
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Error in Main" + e.TargetSite);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Finally");
            }
        }
    }
}