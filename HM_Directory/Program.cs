namespace HM_Directory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hotel hotel = new();

            hotel.AddTenNumbers(2, 750);
            hotel.AddTenNumbers(1, 1500);
            hotel.AddTenNumbers(4, 699);
            hotel.AddTenNumbers(1, 5000);

            hotel.ChekIn("Bob", "Morley", "1234", "345", "Zhytomir", 1, DateTime.Now.AddDays(7));
            hotel.ChekIn("Alex", "Morley", "4563", "534", "Zhytomir", 2, DateTime.Now.AddDays(14));
            hotel.ChekIn("Bob1", "Morley", "1234", "345", "Zhytomir", 3, DateTime.Now.AddDays(2));
            hotel.ChekIn("Bob2", "Morley", "54643", "521", "Zhytomir", 4, DateTime.Now.AddDays(4));
            hotel.ChekIn("Bob3", "Morley", "3456", "345", "Zhytomir", 5, DateTime.Now.AddDays(30));
            hotel.ChekIn("Bob4", "Morley", "2375", "234", "Zhytomir", 6, DateTime.Now.AddDays(1));
            hotel.ChekIn("Bob5", "Morley", "7456", "457", "Zhytomir", 7, DateTime.Now.AddDays(5));
        }
    }
}
