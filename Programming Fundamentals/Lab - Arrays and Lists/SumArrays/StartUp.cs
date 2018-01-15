namespace SumArrays
{
    using System;
    using System.Linq;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var inputLineOne = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var inputLineTwo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var length = Math.Max(inputLineOne.Length, inputLineTwo.Length);
            var result = new int[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = inputLineOne[i % inputLineOne.Length] + inputLineTwo[i % inputLineTwo.Length];
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
