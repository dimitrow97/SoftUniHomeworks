namespace SquareNumbers
{
    using System;
    using System.Linq;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(double.Parse).OrderByDescending(a => a).ToList();

            foreach (var item in input)
            {
                var temp = Math.Sqrt(item);
                if (temp == (int)temp)
                    Console.Write(item + " ");
            }
        }
    }
}
