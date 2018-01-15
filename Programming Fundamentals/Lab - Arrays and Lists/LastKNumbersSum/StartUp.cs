namespace LastKNumbersSum
{
    using System;
    using System.Linq;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var inputFirstLine = int.Parse(Console.ReadLine());
            var inputSecondLine = int.Parse(Console.ReadLine());

            long[] numbers = new long[inputFirstLine];
            numbers[0] = 1;
            
            for(int i = 1; i < inputFirstLine; i++)
            {
                long previousNumbersSum = 0;
                if (i < inputSecondLine)
                    previousNumbersSum = numbers.Sum();
                else
                {
                    for (int j = i - 1; j >= i - inputSecondLine ; j--)
                    {
                        previousNumbersSum += numbers[j];
                    }
                }
                numbers[i] = previousNumbersSum;
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
