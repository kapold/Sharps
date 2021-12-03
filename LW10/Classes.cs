using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LW10
{
    public class Car
    {
        public string Name { set; get; }
        public int Price { set; get; }

        public Car(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

    public class CarList : IList<Car>
    {
        List<Car> List = new List<Car>();

        public void Add(Car item)
        {
            List.Add(item);
        }

        public void Clear()
        {
            List.Clear();
        }

        public bool Contains(Car item)
        {
            return List.Contains(item);
        }

        public void CopyTo(Car[] array, int arrayIndex)
        {
            List.CopyTo(array, arrayIndex);
        }

        public bool Remove(Car item)
        {
            return List.Remove(item);
        }

        public int Count { get; }
        public bool IsReadOnly { get; }
        public int IndexOf(Car item)
        {
            return List.IndexOf(item);
        }

        public void Insert(int index, Car item)
        {
            List.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            List.RemoveAt(index);
        }
        
        public IEnumerator<Car> GetEnumerator()
        {
            foreach (var item in List)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Car this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }

    public class CarDictionary
    {
        public Dictionary<int, Car> list { set; get; }

        public CarDictionary()
        {
            list = new Dictionary<int, Car>();
        }

        public void Print()
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Key}. {item.Value.Name} - {item.Value.Price}$");
            }
        }

        public void Add(int key, Car value)
        {
            list.Add(key, value);
        }

        public void Delete(int key)
        {
            list.Remove(key);
        }

        public int Search(Car searchCar)
        {
            var key = list.First(x => x.Value == searchCar).Key;
            return key;
        }
    }
}