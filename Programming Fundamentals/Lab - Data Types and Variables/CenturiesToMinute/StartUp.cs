namespace CenturiesToMinute
{
    using System;

    class StartUp
    {
        public static void Main(string[] args)
        {
            Console.Write("Centuries: ");
            var input = int.Parse(Console.ReadLine());

            int years = input * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;

            Console.WriteLine($"{input} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
