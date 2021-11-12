using System;
using System.Collections.Generic;
using System.IO;

namespace LW4
{
    class CollectionType<T> : IGeneric<T> where T : class
    {
        private List<T> _collection = new List<T>();
        private string Path = @"D:\Универ 2 курс\Университет 3 семестр\ООП\LW8\LW8\file.txt";

        public void Add(T a)
        {
            _collection.Add(a);
        }

        public void Delete(T a)
        {
            _collection.Remove(a);
        }

        public void View()
        {
            foreach (T b in _collection)
            {
                Console.Write(b + " ");
            }
        }

        public void WriteFile()
        {
            Console.WriteLine();
            try
            {
                using (StreamWriter file1 = new StreamWriter(Path, false, System.Text.Encoding.Default))
                {
                    foreach (T b in _collection)
                    {
                        file1.WriteLine(b.ToString());
                    }
                }

                Console.WriteLine("File is written");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ReadFile()
        {
            try
            {
                using (StreamReader file2 = new StreamReader(Path, System.Text.Encoding.Default))
                {
                    string ln;
                    while ((ln = file2.ReadLine()) != null)
                    {
                        Software text = new Software(ln);
                        _collection.Add(text as T);
                    }
                }
                Console.WriteLine("File is read");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}