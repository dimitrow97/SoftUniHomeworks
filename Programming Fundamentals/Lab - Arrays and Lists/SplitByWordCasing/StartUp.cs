namespace SplitByWordCasing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ',', ';', ' ', '.', ':', '!', '(', ')', '"', '\'', '\\', '/', '[', ']' },
                StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var lowerCase = new List<string>();
            var upperCase = new List<string>();
            var mixedCase = new List<string>();

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].All(char.IsLower))
                {
                    lowerCase.Add(input[i]);
                }
                else if (input[i].All(char.IsUpper))
                {
                    upperCase.Add(input[i]);
                }
                else
                {
                    mixedCase.Add(input[i]);
                }
            }

            Console.WriteLine($"Lower-case: {string.Join(", ", lowerCase)}");
            Console.WriteLine($"Mixed-case: {string.Join(", ", mixedCase)}");
            Console.WriteLine($"Upper-case: {string.Join(", ", upperCase)}");
        }
    }
}
