namespace TripleSum
{
    using System;
    using System.Linq;

    class StartUp
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int count = 0;
            for (int i = 0; i <= input.Length - 2; i++)
            {
                for (int k = 1; k <= input.Length - 1; k++)
                {
                    if (i < k && input.Contains(input[i] + input[k]))
                    {
                        Console.WriteLine($"{input[i]} + {input[k]} == {input[i] + input[k]}");
                        count++;
                    }

                }
            }
            if (count == 0) Console.WriteLine("No");
        }
    }
}
