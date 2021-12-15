using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LW16
{
    public class Numbers // Решето Эратосфена
    {
        public static void SimpleNumbers()
        {
            Console.WriteLine("Введите n: ");
            uint n = Convert.ToUInt32(Console.ReadLine());
            List<uint> numbers = new List<uint>();
            
            // Числа от 2 до n-1
            for (uint i = 0; i < n; i++)
            {
                numbers.Add(i);
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                for (uint j = 0; j < n; j++)
                {
                    numbers.Remove(numbers[i] * j); // Удаляем кратные числа
                }
            }

            Console.WriteLine("Simple Numbers: ");
            foreach (var item in numbers)
            {
                Thread.Sleep(100);
                Console.WriteLine($"{item} ");
            }
        }

        public static int Task1()
        {
            return 5;
        }

        public static int Task2()
        {
            return 10;
        }
        
        public static int Task3()
        {
            return 1;
        }
        
        public static void Display(Task t)
        {
            Console.WriteLine($"ID задачи: {Task.CurrentId}");
            Console.WriteLine($"ID предыдущей задачи: {t.Id}");
            Thread.Sleep(3000);
        }
        
        public static void Display()
        {
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Thread.Sleep(3000);
        }


        public static void Factorial(uint f)
        {
            uint result = 1;
            for (uint i = 1; i <= f; i++)
            {
                result *= i;
            }
            
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Thread.Sleep(3000);
            Console.WriteLine($"Factorial of {f} is {result}");
        }

        public static uint Factorial()
        {
            uint result = 1;
            for (uint i = 1; i <= 10; i++)
            {
                result *= i;
            }
            Thread.Sleep(1000);
            Console.WriteLine($"Factorial: {result}");
            
            return result;
        }
        
        public static async void FactorialAsync()
        {
            Console.WriteLine("Start of FactorialAsync");
            await Task.Run(() => Factorial());
            Console.WriteLine("End of FactorialAsync");
        }
    }
}