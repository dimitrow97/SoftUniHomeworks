namespace ReverseStringArray
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            
            Array.Reverse(input);

            Console.WriteLine(String.Join(" ", input));
        }
    }
}
