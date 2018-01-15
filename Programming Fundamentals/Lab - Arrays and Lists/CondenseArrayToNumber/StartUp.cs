namespace CondenseArrayToNumber
{
    using System;
    using System.Linq;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            while(input.Length != 1)
            {
                var temp = new int[input.Length - 1];
                for (int i = 0; i < input.Length - 1; i++)
                    temp[i] = input[i] + input[i + 1];
                input = temp;
            }

            Console.WriteLine(String.Join(" ", input));
        }
    }
}
