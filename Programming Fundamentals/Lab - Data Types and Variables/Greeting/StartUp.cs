namespace Greeting
{
    using System;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var firstName = Console.ReadLine();
            var lastName = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Hello, {firstName} {lastName}.\r\nYou are {age} years old.");
        }
    }
}
