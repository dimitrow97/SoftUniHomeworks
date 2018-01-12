namespace CircleArea
{
    using System;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var input = double.Parse(Console.ReadLine());
            var result = Math.PI * Math.Pow(input, 2);

            Console.WriteLine($"{result:f12}");
        }
    }
}
