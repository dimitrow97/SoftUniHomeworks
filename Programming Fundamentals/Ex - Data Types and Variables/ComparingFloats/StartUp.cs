namespace ComparingFloats
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            decimal a = decimal.Parse(Console.ReadLine());
            decimal b = decimal.Parse(Console.ReadLine());
            decimal eps = 0.000001m;

            if (Math.Abs(a - b) < eps)            
                Console.WriteLine(true);            
            else Console.WriteLine(false);            
        }
    }
}
