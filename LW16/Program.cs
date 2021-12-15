using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LW16
{
    
    
    class Program
    {
        public static CancellationTokenSource tokenSource = new CancellationTokenSource();
        
        static void Main(string[] args)
        {
            // Task 1: Используя TPL создайте длительную по времени задачу (на основе 
            // Task) на выбор - поиск простых чисел (желательно взять «решето Эратосфена»)
            Console.WriteLine("<------------ Task-1 ------------>");
            Task task = new Task(Numbers.SimpleNumbers);
            Stopwatch stopWatch = new Stopwatch();
            
            stopWatch.Start();
            task.Start();
            task.Wait();
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine($"Runtime: {elapsedTime}");
            
            Console.WriteLine("Информация о задаче: ");
            Console.WriteLine($"ID: {task.Id}\nStatus: {task.Status}");
            
            
            // Task 2: Реализуйте второй вариант этой же задачи с токеном отмены 
            // CancellationToken и отмените задачу.
            Console.WriteLine("<------------ Task-2 ------------>");
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            
            Task taskCopy = new Task(() =>
            {
                CancellationToken tokenForEr = tokenSource.Token;
                
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
                    Thread.Sleep(1000);
                    Console.WriteLine($"{item} ");
                    
                    if (tokenSource.Token.IsCancellationRequested)
                        return;

                    if (tokenForEr.IsCancellationRequested)                      
                    {                                                         
                        Console.WriteLine("\nThe process was stopped.");        
                        break;
                    }
                }
            });
            taskCopy.Start();
            
            Console.WriteLine("Введите 1 для остановки: ");
            string tok = Console.ReadLine();
            if (tok == "1")
            {
                tokenSource.Cancel();
            }
            

            // Task 3: Создайте три задачи с возвратом результата и используйте их для
            // выполнения четвертой задачи. Например, расчет по формуле.
            Console.WriteLine("<------------ Task-3 ------------>");
            Task<int> task1 = new Task<int>(Numbers.Task1);
            Task<int> task2 = new Task<int>(Numbers.Task2);
            Task<int> task3 = new Task<int>(Numbers.Task3);
            Task[] tasks = {
                task1, task2, task3
            };
            foreach (Task t in tasks)
            {
                t.Start();
            }
            Task.WaitAll(tasks);

            double vector = 
                Math.Sqrt(Math.Pow(task1.Result, 2) + Math.Pow(task2.Result, 2) + Math.Pow(task3.Result, 2)); // Формула вектора
            Console.WriteLine($"Vector: {vector}");

            
            // Task 4: Создайте задачу продолжения (continuation task) в двух вариантах:
            //     1) C ContinueWith - планировка на основе завершения множества
            // предшествующих задач
            //     2) На основе объекта ожидания и методов GetAwaiter(),GetResult();
            Console.WriteLine("<------------ Task-4 ------------>");
            /* 1 */
            Task taskID = new Task(()=>{
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
            });
            Task taskContinue = taskID.ContinueWith(Numbers.Display);
            taskID.Start();
            taskContinue.Wait();
            Console.WriteLine("Выполняется работа метода Main");
            /* 2 */
            Task<int> what = Task.Run(() => Enumerable.Range(1, 100000)
                .Count(n=>(n % 2 == 0)));
                // Получаем объект продолжения
            var awaiter = what.GetAwaiter();
                // что делать после окончания предшественника
            awaiter.OnCompleted(() => {
                 // получаем результат вычислений предшественника
                int res = awaiter.GetResult(); // делегат, содержащий код продолжения
                Console.WriteLine(res);
            });


            // Task 5: Используя Класс Parallel распараллельте вычисления циклов For(),
            // ForEach(). Например, на выбор: обработку (преобразования)
            // последовательности, генерация нескольких массивов по 1000000
            // элементов, быстрая сортировка последовательности, обработка текстов
            // (удаление, замена). Оцените производительность по сравнению с
            // обычными циклами.
            Console.WriteLine("<------------ Task-5 ------------>");
            List<uint> list = new List<uint>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            Console.WriteLine("\nParallel loop: ");
            ParallelLoopResult result = Parallel.ForEach<uint>(list, Numbers.Factorial);
            
            Console.WriteLine("\nDefault loop: ");
            foreach (long l in list)                                            
            {                                                                   
                long result1 = 1;  
                
                for (int i = 1; i <= l; i++)
                    result1 *= i;
                Console.WriteLine($"Factorial of {l} is {result1}.");
            }
            
            
            // Task 6: Используя Parallel.Invoke() распараллельте выполнение блока
            // операторов.
            Console.WriteLine("<------------ Task-6 ------------>");
            Console.WriteLine("Parallel.Invoke(): ");
            Parallel.Invoke(Numbers.Display,
                () =>
                {
                    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                    Thread.Sleep(3000);
                },
                () => Numbers.Factorial(5)
            );


            // Task 7: Используя Класс BlockingCollection реализуйте следующую задачу:
            // Есть 5 поставщиков бытовой техники, они завозят уникальные товары
            // на склад (каждый по одному) и 10 покупателей – покупают все подряд,
            // если товара нет - уходят. В вашей задаче: cпрос превышает
            // предложение. Изначально склад пустой. У каждого поставщика своя 
            // скорость завоза товара. Каждый раз при изменении состоянии склада
            // выводите наименования товаров на складе.
            Console.WriteLine("<------------ Task-7 ------------>");
            BlockingCollection<string> bc = new BlockingCollection<string>(5);
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken CToken = cts.Token;

            Task[] consumers = new Task[5]
            {
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(300);
                        bc.Take();
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        bc.Take();
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(600);
                        bc.Take();
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        bc.Take();
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(350);
                        bc.Take();
                    }
                }),
            };

            Task[] sellers = new Task[10]
            {
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Toyota");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Mercedes-Benz");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("BMW");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Honda");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Volkswagen");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Ford");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Hyundai");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Audi");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Porsche");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Nissan");
                    }
                }),
            };

            foreach (var item in consumers)
            {
                if (item.Status != TaskStatus.Running)
                {
                    item.Start();
                }
            }

            foreach (var item in sellers)
            {
                if (item.Status != TaskStatus.Running)
                {
                    item.Start();
                }
            }

            int count = 0;
            while (true)
            {
                if (bc.Count != count && bc.Count != 0)
                {
                    count = bc.Count;
                    Thread.Sleep(500);
                    Console.WriteLine("<--------- Garage --------->");

                    foreach (var item in bc)
                    {
                        Console.WriteLine(item);
                    }

                    if (CToken.IsCancellationRequested)
                    {
                        Console.WriteLine("\nProcess Stopped!");
                        break;
                    }
                    Console.WriteLine("<-------------------------->");
                }
            }
            
            // Task 8: Используя async и await организуйте асинхронное выполнение любого
            // метода.
            Console.WriteLine("<------------ Task-8 ------------>");
            Numbers.FactorialAsync();
        }
    }
}