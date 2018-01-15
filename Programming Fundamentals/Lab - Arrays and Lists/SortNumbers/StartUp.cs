namespace SortNumbers
{
    using System;
    using System.Linq;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();
            input.Sort();

            Console.WriteLine(string.Join(" <= ", input));
        }
    }
}
