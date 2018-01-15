namespace ReverseIntArray
{
    using System;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var numbers = new int[input];

            for(int i = 0; i < input; i++)
            {
                var temp = int.Parse(Console.ReadLine());
                numbers[i] = temp;
            }

            Array.Reverse(numbers);

            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}
