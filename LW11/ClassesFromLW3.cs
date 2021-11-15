using System;

namespace LW11
{
    public class Airline
    {
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
        
        public DateTime time;
        public DateTime Time
        {
            set
            {
                time = value;
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
        public Airline(string destination, int flight_number, string flight_type, string day, DateTime time)
        {
            this.destination = destination;
            this.flight_number = flight_number;
            this.flight_type = flight_type;
            this.day = day;
            this.time = time;
            quantity++;
            
            Print();
        }

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
        
        public override string ToString()
        {
            return ($"\nDestination: {this.destination}\nFlight_number: {this.flight_number}\nFlight_type: {this.flight_type}\nDay: {this.day}\nTime: {this.time}\n");
        }
    }
}