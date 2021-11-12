using System;
using System.Net.Mime;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace LW2
{
    class Program
    {
        static void Main(string[] args)
        {
          (int, int, int, char) LocFunc(int[] intege, string strink)
          {
            int max = intege[0], min = intege[0], sum = 0;
            for (int i = 0; i < intege.Length; i++)
            {
              sum += intege[i];
              if (max < intege[i])
              {
                max = intege[i];
              }
            }
            
            for (int i = 0; i < intege.Length; i++)
            {
              if (min > intege[i])
              {
                min = intege[i];
              }
            }
            var result = (max, min, sum, strink[0]);
            return result;
          }
          
          int Checked_()
          {
            checked
            {
              int n = 2147483647;
              return 0;
            }
          }

          int UnChecked_()
          {
            unchecked
            {
              int n = 2147483647;
              return 0;
            }
          }
            // 1a
              Console.WriteLine("Enter types: ");
              Console.Write("Bool: ");
              bool TF = Convert.ToBoolean(Console.ReadLine());
              Console.Write("Byte: ");
              byte by = Convert.ToByte(Console.ReadLine());
              Console.Write("Char: ");
              char x = Convert.ToChar(Console.ReadLine());
              Console.Write("Decimal: ");
              decimal y = Convert.ToDecimal(Console.ReadLine());
              Console.Write("Double: ");
              double z = Convert.ToDouble(Console.ReadLine());
              Console.Write("Float: ");
              float p = Convert.ToSingle(Console.ReadLine());
              Console.Write("Int: ");
              int i = Convert.ToInt32(Console.ReadLine());
              Console.Write("Long: ");
              long l = Convert.ToInt64(Console.ReadLine());
              Console.Write("SByte: ");
              sbyte s = Convert.ToSByte(Console.ReadLine());
              Console.Write("Short: ");
              short sh = Convert.ToInt16(Console.ReadLine());
              Console.Write("UInt: ");
              uint ui = Convert.ToUInt32(Console.ReadLine());
              Console.Write("ULong: ");
              ulong ul = Convert.ToUInt64(Console.ReadLine());
              Console.Write("UShort: ");
              ushort ush = Convert.ToUInt16(Console.ReadLine());
              Console.Write("String: ");
              string st = Convert.ToString(Console.ReadLine());
            
              Console.WriteLine("\nDifferent types: {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}", TF, by, x, y, z, p, i, l, s, sh, ui, ul, ush, st);

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

              string a9 = a1.Substring(1); // Выделение подстроки
              Console.WriteLine("Substring: " + a9);
              
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
              int[][] Arr = new int[3][];
              Arr[0] = new int[2];
              Arr[1] = new int[3];
              Arr[2] = new int[4];

              Console.WriteLine("Init of Step Massive: ");
              for (i = 0; i < 2; i++)
              {
                int element = Convert.ToInt32(Console.ReadLine());
                Arr[0][i] = element;
              }
              Console.WriteLine();
              for (i = 0; i < 3; i++)
              {
                int element = Convert.ToInt32(Console.ReadLine());
                Arr[1][i] = element;
              }
              Console.WriteLine();
              for (i = 0; i < 4; i++)
              {
                int element = Convert.ToInt32(Console.ReadLine());
                Arr[2][i] = element;
              }
              Console.WriteLine();
              
                // Вывод ступенчатого массива
                Console.WriteLine("Step Massive: ");
                foreach (int[] row in Arr)
                {
                  foreach (int number in row)
                  {
                    Console.Write($"{number} \t");
                  }
                  Console.WriteLine();
                } 
            // 3d
              var s1 = new int[0];
              var s2 = "";
            // 4a
              var cort1 = (5, "Harry", 'c', "Potter", 123456789123456789);
              var cort2 = (125, "Deniel", 'c', "Redclif", 123456789123456789);
            // 4b
              Console.WriteLine($"Cortege: {cort1.Item1}, {cort1.Item2}, {cort1.Item3}, {cort1.Item4}, {cort1.Item5}");
              Console.WriteLine($"Cortege: {cort1.Item1}, {cort1.Item3}, {cort1.Item4}");
            // 4c
              var (b1, b2, b3, b4, b5) = cort1;
              (var c1, var c2, var c3, var c4, var c5) = cort1;
              (int d1, string d2, char d3, string d4, long d5) = cort1;
            // 4d
              if (cort1 == cort2)
              {
                Console.WriteLine("Equal");
              }
              else
              {
                Console.WriteLine("Not Equal");
              }
            // 5
              int[] cortege = new[] { 1, 22, 3, 44, 55, 66, 7, 8 };
              Console.WriteLine(LocFunc(cortege, "Stringgg"));
            // 6
              Checked_();
              UnChecked_();
        }
    }
}