namespace ExchangeValues
{
    using System;

    class StartUp
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"Before:\na = {a}\nb = {b}");

            int temp = b;
            b = a;
            a = temp;
            Console.WriteLine($"After:\na = {a}\nb = {b}");
        }
    }
}
