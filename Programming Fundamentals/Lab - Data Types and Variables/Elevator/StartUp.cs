namespace Elevator
{
    using System;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var inputRowOne = int.Parse(Console.ReadLine());
            var inputRowTwo = int.Parse(Console.ReadLine());

            var result = (int)Math.Ceiling((double)inputRowOne / inputRowTwo);

            Console.WriteLine(result);
        }
    }
}
