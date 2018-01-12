namespace HexFormat
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var result = Convert.ToInt32(input, 16);

            Console.WriteLine(result);
        }
    }
}
