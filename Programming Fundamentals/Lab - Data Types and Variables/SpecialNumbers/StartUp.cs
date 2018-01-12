namespace SpecialNumbers
{
    using System;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            for(int i = 1; i <= input; i++)
            {
                int sum = 0, temp = i;
                while(temp != 0)
                {
                    sum += (temp % 10);
                    temp /= 10;
                }
                string answer = "False";
                if (sum == 5 || sum == 7 || sum == 11) answer = "True";
                Console.WriteLine($"{i} -> {answer}");
            }
            
        }
    }
}
