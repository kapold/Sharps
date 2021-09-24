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

        public string destination;
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
        
        public int flight_number;
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
        
        public string day;
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
            Console.WriteLine("New Flights Are Available");
        }
        private Airline()
        {
            destination = "Unknown";
            flight_number = 0;
            day = "Unknown";
            flight_type = "Unknown";
            time = "Unknown";
            
            // Print();
        }
        public Airline(string destination, int flight_number, string flight_type, string day, string time, string destR, string dayR)
        {
            this.destination = destination;
            this.flight_number = flight_number;
            this.flight_type = flight_type;
            this.day = day;
            this.time = time;
            this.destR = destR;
            this.dayR = dayR;
            quantity++;
            
            Print();
            
            ListOfDestination(ref destR);
            ListOfDays(ref dayR);
            Ret(out dayR);
        }

        public Airline(string con = "default") {} // С параметром по умолчанию

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

        private string destR;
        public string DestR
        {
            set {}
            get { return destR; }

        }
        private string dayR;
        public string DayR { get; set; }
        
        
        public void ListOfDestination(ref string destR)
        {
            if (destination == destR)
            {
                Console.WriteLine("Flight Number(dest): " + flight_number);
            }
        }
        public void ListOfDays(ref string dayR)
        {
            if (day == dayR)
            {
                Console.WriteLine("Flight Number(day): " + flight_number);
            }
        }
        public void Ret(out string dayR)
        {
            dayR = this.dayR;
        }
        
        public readonly int RDONLY = 99;
        public Airline(int rd)
        {
            RDONLY = rd; // поле для чтения может быть инициализировано или изменено в конструкторе после компиляции
        }
        
        
        public override bool Equals(Airline obj)
        {   
            Airline air;
            if (obj == null || (air = obj as Airline) == null)
            {
                return false;
            }
            return  this.destination == air.destination;
        }
        
        private int n {get;}
        public override int GetHashCode()
        {
            return n;
        }

        public override string ToString()
        {
            return ($"\ndestination {this.destination}\nflight_number {this.flight_number}\nflight_type {this.flight_type}\nday {this.day}\ntime {this.time}\n");
        }
    }
    
    public partial class Part
    {
        public void F2()
        {
            Console.WriteLine("The Second(2) Function - Partial");
        }
    }
    
    
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Airline Flight1 = new Airline("Japane", 12, "BelAvia", "Monday", "13:40", "Japane", "Wensday");
            Airline Flight2 = new Airline("Russia", 4, "AviaSales", "Wensday", "10:00","Japane", "Wensday");
            Airline Flight3 = new Airline("China", 3, "Fli", "Friday", "12:20", "Japane", "Wensday");
            Airline[] flights = new Airline[3];
            flights[0] = Flight1;
            flights[1] = Flight2;
            flights[2] = Flight3;
            Airline.Quantity();
            Airline prvt = new Airline(); // Вызов закрытого конструктора


            Console.WriteLine("\nPartial class: ");
            Part prt = new Part();
            prt.F1();
            prt.F2();
            
            Console.WriteLine("GetType: " + Flight1.GetType());
            Console.WriteLine("Equals(changed): " + Flight1.Equals(Flight2));
            Console.WriteLine("GetHashCode: " + Flight1.GetHashCode());
            Console.WriteLine("ToString: " + Flight1.ToString() + "\n");

            Console.WriteLine("Введите пункт назначения: ");
            string CDestination = Console.ReadLine();
            Console.WriteLine("Список рейсов для заданного пункта назначения: ");
            for (int i = 0; i < flights.Length; i++)
            {
                if (flights[i].destination == CDestination)
                {
                    Console.WriteLine("\tНомер рейса: " + flights[i].flight_number);
                }
            }
            
            Console.WriteLine("Введите день: ");
            string CDay = Console.ReadLine();
            Console.WriteLine("Cписок рейсов для заданного дня недели: ");
            for (int i = 0; i < flights.Length; i++)
            {
                if (flights[i].day == CDay)
                {
                    Console.WriteLine("\tНомер рейса: " + flights[i].flight_number);
                }
            }
            
            var anon = new {destination = "USA", time = "13:00", flightNumber = 2};
            Console.WriteLine("Anonim type: " + anon.GetType());
        }
    }
}