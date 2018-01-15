namespace CountNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var occurances = new List<int>();

            for (int i = 0; i < 1000; i++)
                occurances.Add(0);

            foreach (var num in input)
                occurances[num]++;

            for (int num = 0; num < occurances.Count; num++)
                if (occurances[num] > 0)
                    Console.WriteLine(num + " -> " + occurances[num]);
        }
    }
}
