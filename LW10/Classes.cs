using System;
using System.Collections.Generic;
using System.Linq;

namespace LW10
{
    public class Car : IComparable<Car>
    {
        public string Name { set; get; }
        public int Price { set; get; }

        public Car(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public int CompareTo(Car obj)
        {
            return Price.CompareTo(obj);
        }

        public void IsEngineStart(Engine engine)
        {
            if (engine.Power())
            {
                Console.WriteLine($"Поздравляю, {Name} завелась!");
            }
            else
            {
                Console.WriteLine($"Что-то произошло не так.. Видно не судьба.");
            }
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


    public class Engine
    {
        public bool Power()
        {
            var random = new Random();
            bool result = random.Next(2) == 1;
            Console.Write("Попытка завести двигатель: ");
            return result;
        }
    }
}