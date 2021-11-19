using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace LW10
{
    class Program
    {
        static void Main(string[] args)
        {
            // Завозим партию машин :)
            Car Mercedes = new Car("Mercedes-Benz AMG GT 63 S", 160140);
            Car Porsche = new Car("Porsche Taycan Turbo S", 249580);
            Car Audi = new Car("Audi A8 Long 45 TDI IV (D5)", 186600);
            Car Jaguar = new Car("Jaguar XJ Long IV (X351)", 24756);


            // Методы для работа с коллекцией (Dictionary)
            CarDictionary garage = new CarDictionary();
            garage.Add(1, Mercedes);
            garage.Add(2, Porsche);
            garage.Add(3, Audi);
            garage.Add(4, Jaguar);
            garage.Delete(3);
            Console.WriteLine("Гараж машин: ");
            garage.Print();
            Console.WriteLine($"Автомобиль {Mercedes.Name} есть в гараже с ключом {garage.Search(Mercedes)}\n");
            
            
            
            // Обобщенный словарь (Dictionary<TKey, TValue>)
            Dictionary<int, int> GenericDictionary = new Dictionary<int, int>();
            for (int i = 0; i < 10; i++)
            {
                GenericDictionary.Add(i, i);
            }
            
            Console.WriteLine("<-- Обобщенный словарь -->");
            Console.WriteLine("Коллекция int в словаре: ");
            foreach (var item in GenericDictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            
            Console.WriteLine("Удаление элементов: ");
            for (int i = 0; i < 5; i++)
            {
                GenericDictionary.Remove(i);
            }
            foreach (var item in GenericDictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            
            Console.WriteLine("Преобразование словаря в список: ");
            List<int> DictionaryInList = GenericDictionary.Values.ToList();
            foreach (var item in DictionaryInList)
            {
                Console.WriteLine($"{item}");
            }
            
            int count = DictionaryInList.Count;
            Console.Write($"\nКакой элемент найти(элементов: {count}): ");
            int search = Convert.ToInt32(Console.ReadLine());
            int thereIs = 0;
            if (search > count)
                throw new Exception("Error: Такого элемента нет");
            
            Console.WriteLine($"Поиск элемента {search} в списке");
            foreach (var item in DictionaryInList)
            {
                if (item == search)
                {
                    Console.WriteLine("Такой элемент есть!");
                    continue;
                }
                thereIs++;
                if (thereIs == count)
                {
                    Console.WriteLine("Такого элемента нет!");
                }
            }
            
            
            
            // Наблюдаемая коллекция
            ObservableCollection<Car> obsCars = new ObservableCollection<Car>
            {
                new Car("Hyundai Creta II", 17685),
                new Car("BMW X5 IV (G05)", 107072),
                new Car("Kia Rio X IV", 23968)
            };
            
            Console.WriteLine("\nСобытия Observable коллекции: ");
            obsCars.CollectionChanged += CarsCollectionChanged;
            
            obsCars.Add(new Car("Mazda RX-8", 5000));
            obsCars.RemoveAt(1);
            obsCars[0] = new Car("Audo RS8", 72411);
            
            Console.WriteLine("\nСписок машин: ");
            foreach (var item in obsCars)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            
            
            // Обработчик события
            static void CarsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add: // если добавление
                        Car newCar = e.NewItems[0] as Car;
                        Console.WriteLine($"Добавлен новый объект: {newCar.Name}");
                        break;
                    case NotifyCollectionChangedAction.Remove: // если удаление
                        Car oldCar = e.OldItems[0] as Car;
                        Console.WriteLine($"Удален объект: {oldCar.Name}");
                        break;
                    case NotifyCollectionChangedAction.Replace: // если замена
                        Car replacedCar = e.OldItems[0] as Car;
                        Car replacingCar = e.NewItems[0] as Car;
                        Console.WriteLine($"Объект {replacedCar.Name} заменен объектом {replacingCar.Name}");
                        break;
                }
            }

        }
    }
}