using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace LW15
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Определите и выведите на консоль/в файл все запущенные процессы:id, имя, приоритет,
            // время запуска, текущее состояние, сколько всего времени использовал процессор и т.д
            var processes = Process.GetProcesses();
            Console.WriteLine("Информация о процессах: ");
            foreach (Process process in processes)
            {
                Console.WriteLine("<--- Process --->");
                Console.WriteLine($"ID: {process.Id}");
                Console.WriteLine($"ProcessName: {process.ProcessName}");
                Console.WriteLine($"BasePriority: {process.BasePriority}");
                Console.WriteLine($"IsResponding: {process.Responding}");
                Console.WriteLine($"VirtualMemorySize64: {process.VirtualMemorySize64}\n");
            }
            
            // Task 2: Исследуйте текущий домен вашего приложения: имя, детали конфигурации, все сборки,
            // загруженные в домен. Создайте новый домен. Загрузите туда сборку. Выгрузите домен.
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"\n\n\n Домен: {domain.FriendlyName}");
            Console.WriteLine($"Базовый католог: {domain.BaseDirectory}");
            Console.WriteLine($"Детали конфигурации: {domain.SetupInformation}");
            Console.WriteLine("Все сборки в домене: ");
            foreach (Assembly ass in domain.GetAssemblies())
            {
                Console.WriteLine(ass.GetName().Name);
            }
            
            // Task 3: Создайте в отдельном потоке следующую задачу расчета (можно сделать sleep для
            // задержки) и записи в файл и на консоль простых чисел от 1 до n (задает пользователь).
            // Вызовите методы управления потоком (запуск, приостановка, возобновление и т.д.) Во
            // время выполнения выведите информацию о статусе потока, имени, приоритете, числовой
            // идентификатор и т.д
            Thread thread = new Thread(Numbers.SimpleNumbers);
            thread.Priority = ThreadPriority.AboveNormal;
            thread.Start();
            Console.WriteLine("\n\n\nИнформация о потоке: ");
            Console.WriteLine($"Выполняется ли поток: {thread.IsAlive}");
            Console.WriteLine($"Приоритет: {thread.Priority}");
            Console.WriteLine($"ID: {thread.ManagedThreadId}");
            thread.Join();
            
            // Task 4: Создайте два потока. Первый выводит четные числа, второй нечетные до n и
            // записывают их в общий файл и на консоль. Скорость расчета чисел у потоков – разная.
            //    a. Поменяйте приоритет одного из потоков.
            //    b. Используя средства синхронизации организуйте работу потоков, таким образом,
            //    чтобы
            //       i. выводились сначала четные, потом нечетные числа
            //       ii. последовательно выводились одно четное, другое нечетное. 
            Console.WriteLine("\n\n\nЧетные и нечетные числа(введите n): ");
            int n = int.Parse(Console.ReadLine());
            Thread evenThread = new Thread(Numbers.EvenNumbers);
            evenThread.Priority = ThreadPriority.AboveNormal;
            evenThread.Start(n);
            evenThread.Join();
            
            Console.WriteLine();
            Thread oddThread = new Thread(Numbers.OddNumbers);
            oddThread.Priority = ThreadPriority.BelowNormal;
            oddThread.Start(n);
            oddThread.Join();

            // Task 5: Придумайте и реализуйте повторяющуюся задачу на основе класса Timer
            TimerCallback tm = new TimerCallback(Numbers.TimerCls); // Метод обратного вызова
            Timer timer = new Timer(tm, null, 1000, 1000);
            Thread.Sleep(3000);
        }
    }
}