namespace TripleLetters
{
    using System;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
                for (int j = 0; j < input; j++)
                    for (int k = 0; k < input; k++)
                        Console.WriteLine($"{(char)('a' + i)}{(char)('a' + j)}{(char)('a' + k)}");
        }
    }
}
