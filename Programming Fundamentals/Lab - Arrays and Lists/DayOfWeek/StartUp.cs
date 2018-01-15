namespace DayOfWeek
{
    using System;

    class StartUp
    {
        public static void Main(string[] args)
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            var input = int.Parse(Console.ReadLine());

            try { Console.WriteLine(days[input - 1]); }
            catch { Console.WriteLine("Invalid Day!"); }
        }
    }
}
