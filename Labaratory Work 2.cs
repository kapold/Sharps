using System;
using System.Net.Mime;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1a
              bool TF = true;
              byte by = 254;
              char x = 'x';
              decimal y = 453463234;
              double z = 3253434634.324;
              float p = 345.544f;
              int i = -43534523;
              long l = 100;
              sbyte s = 126;
              short sh = 32766;
              uint ui = 4;
              ulong ul = 435345;
              ushort ush = 54334;
              string st = "labka";
            
              Console.WriteLine("Different types: {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}", TF, by, x, y, z, p, i, l, s, sh, ui, ul, ush, st);

            // 1b
              // Неявное преобразование
              int pr1 = by;
              ushort pr2 = by;
              short pr3 = s;
              long pr4 = sh;
              double pr5 = p;
              // Явное преобразование
              byte bt1 = (byte) sh;
              byte bt2 = (byte)(l + s);
              decimal bt3 = (decimal)z;
              double bt4 = (double)i;
              long bt5 = (long)sh;

              short conv = Convert.ToInt16(l);
            // 1c
              int box = 99;
              Object obj1 = box;
              int unbox = (int)box;
            // 1d
              var strNew = "Variable";
              var inNew = 20;
            // 1e
              int? nul = 76;
              Nullable<int> nul2 = 77;
            // 1f
              var last = 999;
              //last = "err";
              /*
                Компилятор увидит, что мы пытаемся присвоить var тип int
                и при переназначении на другой тип он выдаст ошибку.
              */
            // 2a
              string stroka1 = "Welcome";
              string stroka2 = "Home";
              Console.WriteLine("Compare: " + string.Compare(stroka1, stroka2));
            // 2b
              string a1 = "First One";
              string a2 = "Second";
              string a3 = "Third";
              
              string a4 = String.Concat(a1, a2, a3); // Сцепление/Конкатенация
              Console.WriteLine("Concat: " + a4);
              
              string a5 = String.Copy(a4); // Копирование
              Console.WriteLine("Copy: " + a5);

              string a6 = a1.Insert(5, a2); // Вставка подстроки в заданную позицию
              Console.WriteLine("Insert: " + a6);

              string conc = "New String Is Available"; // Разделение строки на слова
              string[] a7 = conc.Split(new char[]{' '});
              foreach (var spli in a7)
              {
                Console.WriteLine("Split:" + spli);
              }

              string a8 = "Removing str"; // Удаление заданной подсроки
              a8 = a8.Remove(a8.Length - 1);
              Console.WriteLine("Removed last symbol: " + a8);
              a8 = a8.Remove(0, 2);
              Console.WriteLine("Removed first 2 symbols: " + a8);
            // 2c
              string Void = "";
              string V2 = null;
              Console.Write("String Is Null or Empty: ");
              if (String.IsNullOrEmpty(V2))
              {
                Console.WriteLine("null or empty");
              }
              else
              {
                Console.WriteLine("Full string");
              }
            // 2d
              StringBuilder steve = new StringBuilder("Hi, my name is Steve");
              steve.Remove(4, 7);
              steve.Insert(0, "New ");
              steve.Append(" New");
            // 3a
              int[,] numbers = { {1, 2, 3}, {4, 5, 6}, {7, 8, 9} };
              int rows = numbers.GetUpperBound(0) + 1;
              int columns = numbers.Length / rows;

              for (i = 0; i < rows; i++)
              {
                for (int j = 0; j < columns; j++)
                {
                  Console.Write($"{numbers[i,j]} \t");
                }
                Console.WriteLine();
              }
            // 3b
              string[] master = { "Red", "Green", "Blue"};
              Console.WriteLine("Massive str: ");
              foreach (var stroki in master)
              {
                Console.WriteLine("\t" + stroki);
              }
              Console.WriteLine("Length of MassiveOfStr: " + master.Length);
              Console.Write("Choose the element: ");
              int elem = Convert.ToInt16(Console.ReadLine()) - 1;
              for (i = 0; i < master.Length; i++)
              {
                if (i == elem)
                {
                  Console.Write("Exchange: ");
                  master[i] = Console.ReadLine();
                }
              }
              Console.WriteLine("Exchanged str: ");
              for (i = 0; i < master.Length; i++)
              {
                Console.WriteLine("\t" + master[i]);
              }
            // 3c
              
              
              
            // 3d
              var s1 = new int[0];
              var s2 = "";
            // 4a
        }
    }
}