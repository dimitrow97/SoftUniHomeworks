namespace IntegerSizes
{
    using System;
    using System.Numerics;

    class StartUp
    {
        static void Main(string[] args)
        {
            string numAsString = Console.ReadLine();
            BigInteger number;
            bool numberFitsInBigInteger = BigInteger.TryParse(numAsString, out number);

            int lenght = numAsString.Length;

            if (number >= long.MinValue && number <= long.MaxValue)
            {
                Console.WriteLine($"{numAsString} can fit in:");
                if (number >= sbyte.MinValue && number <= sbyte.MaxValue) Console.WriteLine("* sbyte");
                if (number >= byte.MinValue && number <= byte.MaxValue) Console.WriteLine("* byte");
                if (number >= short.MinValue && number <= short.MaxValue) Console.WriteLine("* short");
                if (number >= ushort.MinValue && number <= ushort.MaxValue) Console.WriteLine("* ushort");
                if (number >= int.MinValue && number <= int.MaxValue) Console.WriteLine("* int");
                if (number >= uint.MinValue && number <= uint.MaxValue) Console.WriteLine("* uint");
                if (number >= long.MinValue && number <= long.MaxValue) Console.WriteLine("* long");
            }
            else
            {
                Console.WriteLine($"{numAsString} can't fit in any type");
            }
        }
    }
}
