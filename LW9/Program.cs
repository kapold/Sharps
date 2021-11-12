using System;

namespace LW9
{
    class Program
    {
        static void Main(string[] args)
        {
            // Лямбда
            Sum summa = (x, y) => x + y;
            Console.WriteLine($"Сумма через лямбду: { summa(199, 299) }\n");
            
            // User 
            Specialists user = new Specialists();
            user.move += DisplayMessage;
            user.zip += DisplayMessage;

            user.add("Ivan");
            user.add("Dima");
            user.add("Maks");
            user.add("Aleksei");
            user.add("Darya");
            user.view();
            user.Replace();
            user.view();

            Console.WriteLine("Введите кого нужно удалить: ");
            string member = Console.ReadLine();
            user.delete(member);
            user.view();
            
            user.Zipper();
            user.view();
            
            
            // Hotel
            Hotel visitors = new Hotel();
            visitors.move += DisplayMessage;
            
            Console.WriteLine("<-- Welcome to the Hotel -->");
            Console.Write("Сколько посетителей заселяем: ");
            AddVisitor notify = () => Console.Write("Добавьте посетителя: ");
            int CountOfVisitors = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < CountOfVisitors; i++)
            {
                notify();
                string name = Console.ReadLine();
                visitors.add(name);
            }
            
            Console.Write($"Скольких жителей нужно переместить(не более {CountOfVisitors}): ");
            int CountOfMove = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < CountOfMove; i++)
            {
                if (CountOfVisitors < CountOfMove)
                {
                    throw new Exception("Error: Количество перемещений больше, чем самих посетителей");
                }
                else
                    visitors.Replace();
            }
            visitors.view();
            Console.WriteLine("<-- Bye, see you soon -->");
            
            
            // Методы для строк
            Console.WriteLine("Обработка строки: ");
            string str = "a,b. c! d? F";
            Func<string, string> funcStr;
            
            Console.WriteLine($"Исходная строка: {str}");
            funcStr = String.RemoveStr;
            Console.WriteLine($"Без знаков препинания: {str = funcStr(str)}");
            funcStr = String.DeleteSpaces;
            Console.WriteLine($"Без пробелов: {str = funcStr(str)}");
            funcStr = String.Upper;
            Console.WriteLine($"С заглавными буквами: {str = funcStr(str)}");
            funcStr = String.Lower;
            Console.WriteLine($"Со строчными буквами: {str = funcStr(str)}");
            funcStr = String.AddToString;
            Console.WriteLine($"С добавлением символа: {str = funcStr(str)}");
            

            // Обработчик событий
            static void DisplayMessage(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
}