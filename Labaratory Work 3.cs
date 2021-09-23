using System;

namespace LW3
{
    /*
     Создать класс Airline: Cодержит : Пункт назначения,
     Номер рейса, Тип самолета, Время вылета, Дни недели.
     Свойства и конструкторы должны обеспечивать проверку
     корректности.
     Создать массив объектов. Вывести:
     a) список рейсов для заданного пункта назначения;
     b) список рейсов для заданного дня недели;
    */
    public class Airline
    {
        public const double PI = Math.PI;
        public static int ID { get; private set; } = 0;

        private string destination;
        public string Destination
        {
            set
            {
                destination = value;
            }
            get
            {
                return destination;
            }
        }
        
        private int flight_number;
        public int FlightNumber
        {
            set
            {
                flight_number = value;
            }
            get
            {
                return flight_number;
            }
        }
        
        private string flight_type;
        public string FlightType
        {
            set
            {
                if (flight_type == null)
                {
                    Console.WriteLine("Тип самолета не выбран");
                }
                else
                {
                    flight_type = value;

                }
            }
            get
            {
                return flight_type;
            }
        }
        
        private string time;
        public string Time
        {
            set
            {
                if (time == null)
                {
                    Console.WriteLine("Время не выбрано");
                }
                else
                {
                    time = value;
                }
            }
            get
            {
                return time;
            }
        }
        
        private string day;
        public string Day
        {
            set
            {
                if (day == null)
                {
                    Console.WriteLine("Дни не выбраны");
                }
                else
                {
                    day = value;
                }
            }
            get
            {
                return day;
            }
        }
        
        static int quantity = 0;
        static Airline()
        {
            Console.WriteLine("New Flight");
        }
        public Airline()
        {
            destination = "Unknown";
            flight_number = 0;
            day = "Unknown";
            flight_type = "Unknown";
            time = "Unknown";
            
            Print();
        }
        public Airline(string destination, int flight_number, string flight_type, string day, string time)
        {
            this.destination = destination;
            this.flight_number = flight_number;
            this.flight_type = flight_type;
            this.day = day;
            this.time = time;
            quantity++;
            
            Print();
            
            //ListOfDestination(ref destination);
            //ListOfDays(ref day);
        }

        public Airline(string con = "default") {} // С параметром по умолчанию
        // private Airline() { } // Закрытый конструктор
        
        public void Print()
        {
            Console.WriteLine("\n<----------FLIGHT---------->");
            Console.WriteLine("Destination: " + destination);
            Console.WriteLine("FlightNumber: " + flight_number);
            Console.WriteLine("AircraftType: " + flight_type);
            Console.WriteLine("Day: " + day);
            Console.WriteLine("Time: " + time);
            Console.WriteLine("<----------FLIGHT----------> \n ");
        }
        public static void Quantity()
        {
            Console.WriteLine("Количество созданных объектов: " + quantity);
        }
        public void ListOfDestination()
        {
            if (destination == "Japane")
            {
                Console.WriteLine("Flight Number: " + flight_number);
            }
            else
            {
                Console.WriteLine("Таких рейсов нет");
            }
        }
        public void ListOfDays()
        {
            if (day == "Wensday")
            {
                Console.WriteLine("Flight Number: " + flight_number);
            }
            else
            {
                Console.WriteLine("Таких рейсов нет");
            }
        }
        
        public readonly int RDONLY = 99;
        public Airline(int rd)
        {
            RDONLY = rd; // поле для чтения может быть инициализировано или изменено в конструкторе после компиляции
        }
        
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Airline Flight1 = new Airline("Japane", 12, "BelAvia", "Monday", "13:40");
            Airline Flight2 = new Airline("Russia", 4, "AviaSales", "Wensday", "10:00");
            Airline Flight3 = new Airline("China", 3, "Fli", "Friday", "12:20");
            Airline[] flights = new Airline[3];
            flights[0] = Flight1;
            flights[1] = Flight1;
            flights[2] = Flight1;
            Airline.Quantity();
            // Airline prvt = new Airline(); // Вызов закрытого конструктора

            Flight1.ListOfDestination();
            Flight2.ListOfDays();
        }
    }
}