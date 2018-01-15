namespace RemoveNegativeReverse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var result = input.Where(x => x > 0).ToList();

            if (result.Count() == 0) Console.WriteLine("empty");
            else
            {
                result.Reverse();
                Console.WriteLine(String.Join(" ", result));
            }
        }
    }
}
