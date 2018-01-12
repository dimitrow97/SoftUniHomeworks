namespace ExactSum
{
    using System;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            decimal result = 0m;

            for(int i=0; i < input; i++)
            {
                var value = decimal.Parse(Console.ReadLine());
                result += value;
            }

            Console.WriteLine(result);
        }
    }
}
