using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace LW15
{
    public class Numbers
    {
        public static void SimpleNumbers()
        {
            Thread.Sleep(1000);
            List<int> numbers = new List<int>();
            Console.WriteLine("\n\n\nВведите n: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                var isSimple = true;
                for (int j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        isSimple = false;
                        break;
                    }
                }

                if (isSimple)
                {
                    numbers.Add(i);
                    Console.WriteLine($"{i} ");
                    Thread.Sleep(100);
                }
            }

            string path = 
                Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW15\LW15\SimpleNumbers.txt");
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine("Simple Numbers: ");
                foreach (var item in numbers)
                {
                    sw.WriteLine(item);
                }
            }
        }

        public static void EvenNumbers(object num)
        {
            int n = (int) num;
            List<int> evenNum = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    evenNum.Add(i);
                    Console.Write($"{i} ");
                    Thread.Sleep(100);
                }
            }
            
            string path = 
                Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW15\LW15\EvenAndOddNumbers.txt");
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine("Even Numbers: ");
                foreach (var item in evenNum)
                {
                    sw.Write(item + " ");
                }
            }
        }

        public static void OddNumbers(object num)
        {
            int n = (int) num;
            List<int> oddNum = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (i % 2 != 0)
                {
                    oddNum.Add(i);
                    Console.Write($"{i} ");
                    Thread.Sleep(100);
                }
            }

            string path = 
                Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW15\LW15\EvenAndOddNumbers.txt");
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("\nOdd Numbers: ");
                foreach (var item in oddNum)
                {
                    sw.Write(item + " ");
                }
            }
            Console.WriteLine();
        }

        public static void TimerCls(object obj)
        {
            Console.WriteLine("Time is out!");
        }
    }
}