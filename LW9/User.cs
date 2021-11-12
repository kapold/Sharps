using System;
using System.Collections.Generic;

namespace LW9
{
    public delegate void Message(string s);
    public delegate int Sum(int x, int y);
    public delegate void AddVisitor();

    public class Specialists
    {
        public event Message move;
        public event Message zip;

        List<string> list = new List<string>();
        
        public string this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }

        public void add(string item)
        {
            list.Add(item);
        }

        public void delete(string item)
        {
            list.Remove(item);
            Console.WriteLine($"<-- User {item} deleted -->");
        }

        public void view()
        {
            Console.WriteLine("List: ");
            foreach (var i in list)
            {
                Console.WriteLine(i + " ");
            }
            Console.WriteLine();
        }
        
        public void Replace()
        {
            Console.WriteLine("Select user and place: ");
            string newUser = Console.ReadLine();
            int place = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine();
            list.Remove(newUser);
            list.Insert(place, newUser);
            
            move?.Invoke("<-- User replaced -->");
        }

        public void Zipper()
        {
            double quantity = 0;
            double comprassionRatio = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int comprassion = list[i].Length - 1;
                list[i] = list[i].Substring(0, 1);
                quantity += comprassion;
            }

            comprassionRatio = quantity / list.Count; // Средний коэффициент сжатия
            
            move?.Invoke("<-- User zipped -->");
            move?.Invoke($"<-- Коэффициент сжатия : {comprassionRatio} -->");
        }
    }

    public class Hotel
    {
        public event Message move;

        List<string> spisok = new List<string>();
        
        public string this[int index]
        {
            get { return spisok[index]; }
            set { spisok[index] = value; }
        }
        
        public void add(string item)
        {
            spisok.Add(item);
        }

        public void view()
        {
            Console.WriteLine("List: ");
            foreach (var i in spisok)
            {
                Console.WriteLine(i + " ");
            }
            Console.WriteLine();
        }
        
        public void Replace()
        {
            Console.WriteLine("Select user and place: ");
            string newUser = Console.ReadLine();
            int place = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine();
            spisok.Remove(newUser);
            spisok.Insert(place, newUser);
            
            move?.Invoke("<-- User replaced -->");
        }
    }
}