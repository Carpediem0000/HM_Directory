using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace HM_Directory
{
    internal class Hotel
    {
        public List<Client> Clients {  get; set; } = new List<Client>();
        public List<Living> Living { get; set; } = new List<Living>();
        public List<HotelNumber> HotelNumbers { get; set; } = new List<HotelNumber>();
        public List<TypeOfHotelNumber> TypeOfHotelNumbers { get; set; } = new List<TypeOfHotelNumber>();
        public Hotel()
        {
            string path = Directory.GetCurrentDirectory() + @"\Hotel";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

                if (Clients.Count > 0)
                    SaveListToJson(Clients, path + @"\clients.json");
                if (Living.Count > 0)
                    SaveListToJson(Living, path + @"\living.json");
                if (HotelNumbers.Count > 0)
                    SaveListToJson(HotelNumbers, path + @"\hotelNumbers.json");
                if (TypeOfHotelNumbers.Count > 0)
                    SaveListToJson(TypeOfHotelNumbers, path + @"\typeOfHotelNumbers.json");
            }
            else
            {
                if (Directory.Exists(path + @"\clients.json"))
                {
                    string jsonData = File.ReadAllText(path + @"\clients.json");
                    Clients = JsonConvert.DeserializeObject<List<Client>>(jsonData);
                }
                if (Directory.Exists(path + @"\living.json"))
                {
                    string jsonData = File.ReadAllText(path + @"\living.json");
                    Living = JsonConvert.DeserializeObject<List<Living>>(jsonData);
                }
                if (Directory.Exists(path + @"\hotelNumbers.json"))
                {
                    string jsonData = File.ReadAllText(path + @"\hotelNumbers.json");
                    HotelNumbers = JsonConvert.DeserializeObject<List<HotelNumber>>(jsonData);
                }
                if (Directory.Exists(path + @"\typeOfHotelNumbers.json"))
                {
                    string jsonData = File.ReadAllText(path + @"\typeOfHotelNumbers.json");
                    TypeOfHotelNumbers = JsonConvert.DeserializeObject<List<TypeOfHotelNumber>>(jsonData);
                }
            }
        }
        public Hotel(IEnumerable<Client> clients, IEnumerable<Living> living, IEnumerable<HotelNumber> hotelNumbers, IEnumerable<TypeOfHotelNumber> typeOfHotelNumbers)
        {
            Clients = clients.ToList();
            Living = living.ToList();
            HotelNumbers = hotelNumbers.ToList();
            TypeOfHotelNumbers = typeOfHotelNumbers.ToList();

            string path = Directory.GetCurrentDirectory() + @"\Hotel";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

                if (Clients.Count > 0)
                    SaveListToJson(Clients, path + @"\clients.json");
                if (Living.Count > 0)
                    SaveListToJson(Living, path + @"\living.json");
                if (HotelNumbers.Count > 0)
                    SaveListToJson(HotelNumbers, path + @"\hotelNumbers.json");
                if (TypeOfHotelNumbers.Count > 0)
                    SaveListToJson(TypeOfHotelNumbers, path + @"\typeOfHotelNumbers.json");
            }
            else
            {
                if (Directory.Exists(path + @"\clients.json"))
                {
                    string jsonData = File.ReadAllText(path + @"\clients.json");
                    Clients = JsonConvert.DeserializeObject<List<Client>>(jsonData);
                }
                if (Directory.Exists(path + @"\living.json"))
                {
                    string jsonData = File.ReadAllText(path + @"\living.json");
                    Living = JsonConvert.DeserializeObject<List<Living>>(jsonData);
                }
                if (Directory.Exists(path + @"\hotelNumbers.json"))
                {
                    string jsonData = File.ReadAllText(path + @"\hotelNumbers.json");
                    HotelNumbers = JsonConvert.DeserializeObject<List<HotelNumber>>(jsonData);
                }
                if (Directory.Exists(path + @"\typeOfHotelNumbers.json"))
                {
                    string jsonData = File.ReadAllText(path + @"\typeOfHotelNumbers.json");
                    TypeOfHotelNumbers = JsonConvert.DeserializeObject<List<TypeOfHotelNumber>>(jsonData);
                }
            }
        }
        public Hotel(IEnumerable<HotelNumber> hotelNumbers, IEnumerable<TypeOfHotelNumber> typeOfHotelNumbers)
        {
            HotelNumbers = hotelNumbers.ToList();
            TypeOfHotelNumbers = typeOfHotelNumbers.ToList();

            string path = Directory.GetCurrentDirectory() + @"\Hotel";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

                if (Clients.Count > 0)
                    SaveListToJson(Clients, path + @"\clients.json");
                if (Living.Count > 0)
                    SaveListToJson(Living, path + @"\living.json");
                if (HotelNumbers.Count > 0)
                    SaveListToJson(HotelNumbers, path + @"\hotelNumbers.json");
                if (TypeOfHotelNumbers.Count > 0)
                    SaveListToJson(TypeOfHotelNumbers, path + @"\typeOfHotelNumbers.json");
            }
            else
            {
                if (Directory.Exists(path + @"\clients.json"))
                {
                    string jsonData = File.ReadAllText(path + @"\clients.json");
                    Clients = JsonConvert.DeserializeObject<List<Client>>(jsonData);
                }
                if (Directory.Exists(path + @"\living.json"))
                {
                    string jsonData = File.ReadAllText(path + @"\living.json");
                    Living = JsonConvert.DeserializeObject<List<Living>>(jsonData);
                }
                if (Directory.Exists(path + @"\hotelNumbers.json"))
                {
                    string jsonData = File.ReadAllText(path + @"\hotelNumbers.json");
                    HotelNumbers = JsonConvert.DeserializeObject<List<HotelNumber>>(jsonData);
                }
                if (Directory.Exists(path + @"\typeOfHotelNumbers.json"))
                {
                    string jsonData = File.ReadAllText(path + @"\typeOfHotelNumbers.json");
                    TypeOfHotelNumbers = JsonConvert.DeserializeObject<List<TypeOfHotelNumber>>(jsonData);
                }
            }
        }

        //Methods
        private void SaveListToJson<T>(List<T> list, string filePath)
        {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        public void ChekIn(string firstName, string lastName, string passportSeries, string passportNumber, string city, int hotelNumberId, DateTime dateOut) //Заселить
        {
            if (!HotelNumbers.Select(h => h.Id).Contains(hotelNumberId))
            {
                Console.WriteLine("Такого номера не существует!");
                return;
            }
            if (HotelNumbers.Where(i => i.Id == hotelNumberId).FirstOrDefault().IsFree == false)
            {
                Console.WriteLine("Этот номер занят!");
                return;
            }

            Client newClient = new Client(firstName, lastName, passportSeries, passportNumber, city);
            Clients.Add(newClient);

            var hotelNumber = HotelNumbers.FirstOrDefault(i => i.Id == hotelNumberId);
            double cost = TypeOfHotelNumbers.FirstOrDefault(id => id.Id == hotelNumber.TypeOfHotelNumberId).Cost;
            int dayCount = (dateOut - DateTime.Now).Days + 1;

            Living newLiving = new Living(Clients.Last().Id, hotelNumberId, dayCount * cost, DateTime.Now, dateOut);
            Living.Add(newLiving);

            var hotelNumberIndex = HotelNumbers.FindIndex(i => i.Id == hotelNumberId);
            string path = Directory.GetCurrentDirectory() + @"\Hotel";
            if (hotelNumberIndex != -1)
            {
                HotelNumbers[hotelNumberIndex].IsFree = false;
                SaveListToJson(HotelNumbers, path + @"\hotelNumbers.json");
            }

            Console.WriteLine($"Клиент: {firstName + " " + lastName} успешно заселен");

            SaveListToJson(Clients, path + @"\clients.json");
            SaveListToJson(Living, path + @"\living.json");

        }

        public void ChekOut(int id) //Выселить
        {
            if (Living.Contains(Living.Where(c => c.IdClient == id).FirstOrDefault()))
            {
                Console.WriteLine($"Клиент с таким id не проживат в отеле");
                return;
            }
            HotelNumbers.Where(i => i.Id == Living.Where(c => c.IdClient == id).FirstOrDefault().HotelNumberId).FirstOrDefault().IsFree = true;
            Living.Remove(Living.Where(c => c.IdClient == id).FirstOrDefault());
            Console.WriteLine($"Клиент успешно выселен");

            string path = Directory.GetCurrentDirectory() + @"\Hotel";
            SaveListToJson(Clients, path + @"\clients.json");
            SaveListToJson(Living, path + @"\living.json");
        }

        public void AddTenNumbers(int numberOfSeats, double cost) //Добавляет 10 новеров(случайно генерирует этаж)
        {
            TypeOfHotelNumber typeOfHotelNumber = new(numberOfSeats, cost);
            TypeOfHotelNumbers.Add(typeOfHotelNumber);

            Random random = new Random();
            int randomNumber;
            for (int i = 0; i < 10; i++)
            {
                randomNumber = random.Next(1, 11);
                HotelNumber hotelNumber = new(typeOfHotelNumber.Id, randomNumber);
                HotelNumbers.Add(hotelNumber);
            }

            string path = Directory.GetCurrentDirectory() + @"\Hotel";
            SaveListToJson(HotelNumbers, path + @"\hotelNumbers.json");
            SaveListToJson(TypeOfHotelNumbers, path + @"\typeOfHotelNumbers.json");
        }
    }
    public class Client
    {
        static int Counter = 1;
        public int Id {  get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string City { get; set; }
        public Client(string firstName, string lastName, string passportSeries, string passportNumber, string city)
        {
            Id = Counter++;
            FirstName = firstName;
            LastName = lastName;
            PassportSeries = passportSeries;
            PassportNumber = passportNumber;
            City = city;
        }
        public override string ToString()
        {
            string res = string.Empty;
            res += $"Id: {Id}\n";
            res += $"FirstName: {FirstName}\n";
            res += $"LastName: {LastName}\n";
            res += $"City: {City}";
            return res;
        }
    }
    public class Living
    {
        public int IdClient { get; }
        public int HotelNumberId { get; set; }
        public double Cost { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public Living(int idClient, int hotelNumberId, double cost, DateTime dateIn, DateTime dateOut)
        {
            IdClient = idClient;
            HotelNumberId = hotelNumberId;
            Cost = cost;
            DateIn = dateIn;
            DateOut = dateOut;
        }
        public override string ToString()
        {
            string res = string.Empty;
            res += $"Id: {IdClient}\n";
            res += $"Hotel number id: {HotelNumberId}\n";
            res += $"Cost: {Cost}\n";
            res += $"DateIn: {DateIn.ToShortDateString()}\n";
            res += $"DateOut: {DateOut.ToShortDateString()}";
            return res;
        }
    }
    public class HotelNumber
    {
        static int Counter = 1;
        public int Id { get; }
        public int TypeOfHotelNumberId { get; } 
        public int Floor { get; }
        public bool IsFree { get; set; }
        public HotelNumber(int typeOfHotelNumberId, int floor)
        {
            Id = Counter++;
            TypeOfHotelNumberId = typeOfHotelNumberId;
            Floor = floor;
            IsFree = true;
        }
        public override string ToString()
        {
            string res = string.Empty;
            res += $"Id: {Id}\n";
            res += $"Type of hotel number id: {TypeOfHotelNumberId}\n";
            res += $"Floor: {Floor}";
            return res;
        }
    }
    public class TypeOfHotelNumber
    {
        static int Counter = 1;
        public int Id { get; }
        public int NumberOfSeats { get; }
        public double Cost { get; }
        public TypeOfHotelNumber(int numberOfSeats, double cost)
        {
            Id = Counter++;
            NumberOfSeats = numberOfSeats;
            Cost = cost;
        }
        public override string ToString()
        {
            string res = string.Empty;
            res += $"Id: {Id}\n";
            res += $"Number of seats: {NumberOfSeats}\n";
            res += $"Cost: {Cost}";
            return res;
        }
    }
}
