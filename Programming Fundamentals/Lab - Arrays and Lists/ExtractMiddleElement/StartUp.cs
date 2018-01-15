namespace ExtractMiddleElement
{
    using System;
    using System.Linq;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int length = input.Length;

            if (length == 1)
                Console.WriteLine($"{{ {input[0]} }}");
            else if(length % 2 == 0)            
                Console.WriteLine($"{{ {input[length / 2 - 1]}, {input[length / 2]} }}");
            else Console.WriteLine($"{{ {input[length / 2 - 1]}, {input[length / 2]}, {input[length / 2 + 1]} }}");
        }
    }
}
