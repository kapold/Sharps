using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LW11
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            // (Задайте массив типа string, содержащий 12 месяцев (June, July, May,
            // December, January ….). Используя LINQ to Object напишите запрос выбирающий
            // последовательность месяцев с длиной строки равной n, запрос возвращающий
            // только летние и зимние месяцы, запрос вывода месяцев в алфавитном порядке,
            // запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х..)
            string[] months =
            {
                "January", "February", "March", "April", "May", "June", "July",
                "August", "September", "October", "November", "December"
            };
            
            Console.WriteLine("Введите n(длина строки месяцев): ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine($"Месяцы состоящие из {n} букв: ");
            var monthsN = from m in months
                where m.Length == n
                orderby m
                select m;
            foreach (var item in monthsN)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            
            
            Console.WriteLine("Только летние и зимние месяцы: ");
            var summerAndWinter = from m in months
                where Array.IndexOf(months, m) < 2 || (Array.IndexOf(months, m) > 4 && Array.IndexOf(months, m) < 8) ||
                      Array.IndexOf(months, m) > 10
                select m;
            foreach (var item in summerAndWinter)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            
            
            Console.WriteLine("Месяца в алфавитном порядке: ");
            var orderedMoths = from m in months
                orderby m
                select m;
            foreach (var item in orderedMoths)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            
            
            Console.WriteLine("Месяцы содержащие букву «u» и длиной имени не менее 4-х: ");
            var monthsU4 = from m in months
                where m.Length >= 4 && Regex.IsMatch(m, "u")
                select m;
            foreach (var item in monthsU4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            
            
            // Задание 2
            Airline Flight1 = new Airline("Monako", 1, "common", "Monday", new DateTime(2021, 11, 15, 18, 30, 00));
            Airline Flight2 = new Airline("Bali", 2, "common", "Yuesday", new DateTime(2021, 11, 15, 15, 00, 00));
            Airline Flight3 = new Airline("Belarus", 3, "common", "Wednesday", new DateTime(2021, 11, 15, 12, 30, 00));
            Airline Flight4 = new Airline("Russia", 4, "common", "Monday", new DateTime(2021, 11, 15, 14, 00, 00));
            Airline Flight5 = new Airline("USA", 5, "common", "Friday", new DateTime(2021, 11, 15, 12, 45, 00));
            Airline Flight6 = new Airline("Ukrain", 6, "common", "Monday", new DateTime(2021, 11, 15, 11, 30, 00));
            Airline Flight7 = new Airline("UK", 7, "common", "Yuesday", new DateTime(2021, 11, 15, 10, 00, 00));
            Airline Flight8 = new Airline("Russia", 8, "common", "Wednesday", new DateTime(2021, 11, 15, 5, 30, 00));
            Airline Flight9 = new Airline("Italy", 9, "common", "Monday", new DateTime(2021, 11, 15, 9, 00, 00));
            Airline Flight10 = new Airline("USA", 10, "common", "Friday", new DateTime(2021, 11, 15, 2, 45, 00));

            List<Airline> listOfFlights = new List<Airline>()
            {
                Flight1, Flight2, Flight3, Flight4, Flight5, Flight6, Flight7, Flight8, Flight9, Flight10
            };
            
            // Задание 3

            Console.WriteLine("Список рейсов для заданного пункта назначения(введите пункт): ");
            string Destin = Console.ReadLine();
            var currentDestination = from m in listOfFlights
                where m.destination == Destin
                select m;
            foreach (var item in currentDestination)
            {
                Console.WriteLine(item.ToString());
            }

            
            Console.WriteLine("Количество рейсов для заданного дня недели(введите день): ");
            string Day = Console.ReadLine();
            int countOfFlights = listOfFlights.Count();
            countOfFlights = listOfFlights.Count(m => m.day == Day);
            Console.WriteLine(countOfFlights);
            
            Console.WriteLine("Рейс который вылетает в понедельник раньше всех: ");
            var monday = from m in listOfFlights
                where m.day == "Monday"
                select m;
            var time = from m in monday
                orderby m.time
                select m;

            var firstTime = time.Take(1);
            foreach (var item in firstTime)
            {
                item.Print();
            }
            
            Console.WriteLine("Рейс который вылетает в среду или пятницу позже всех: ");
            var wednesdayFriday = from m in listOfFlights
                where m.day == "Wednesday" || m.day == "Friday"
                select m;
            var laterTime = from m in wednesdayFriday
                orderby m.time descending
                select m;
            foreach (var item in laterTime.Take(1))
            {
                item.Print();
            }

            Console.WriteLine("Список рейсов, упорядоченных по времени вылета: ");
            var sortedTimeFlights = from m in listOfFlights
                orderby m.time ascending
                select m;
            foreach (var item in sortedTimeFlights)
            {
                Console.WriteLine(item.ToString());
            }
            
            
            // Задание 4
            Console.WriteLine("<-- Кастомный запрос -->");
            var customLINQ = from m in listOfFlights
                where m.destination == "USA" && m.day == "Friday"
                orderby m.time ascending
                select m;
            var CountCustom = customLINQ.Count();
            Console.Write($"Количество подходящих рейсов: {CountCustom}\n");
            Console.WriteLine("Самый ранний рейс: ");
            foreach (var item in customLINQ.Take(1))
            {
                item.Print();
            }

            // Задание 5 (с Join)
            Console.WriteLine("Join: ");
            string[] flightNames =
            {
                "USA", "Belarus", "Russia", "Ukrain"
            };
            int[] flightLength =
            {
                1, 2, 3, 4, 6, 7
            };

            var someFlights = flightNames
                .Join(
                    flightLength,               // внутренняя
                    w => w.Length,          // внешний ключ выбора
                    q => q,                   // внутренний ключ выбора
                    (w, q) => new        // результат
                    {
                        name = w,
                        id = String.Format("{0} ", q),
                    });
            foreach (var item in someFlights)
            {
                Console.WriteLine(item);
            }
        }
    }
}