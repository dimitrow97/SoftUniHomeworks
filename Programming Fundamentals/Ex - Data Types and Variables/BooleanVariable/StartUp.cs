namespace BooleanVariable
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            if (input == "true") Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}
