namespace RoundingNumbers
{
    using System;
    using System.Linq;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
                Console.WriteLine($"{input[i]} => {Math.Round(input[i], MidpointRounding.AwayFromZero)}");
        }
    }
}
