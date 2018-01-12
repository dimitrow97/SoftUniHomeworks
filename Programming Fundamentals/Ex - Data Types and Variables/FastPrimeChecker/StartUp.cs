namespace FastPrimeChecker
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 2; i <= num; i++)
            {
                bool result = true;
                for (int n = 2; n <= Math.Sqrt(i); n++)
                {
                    if (i % n == 0)
                    {
                        result = false;
                        break;
                    }
                }
                Console.WriteLine($"{i} -> {result}");
            }
        }
    }
}
