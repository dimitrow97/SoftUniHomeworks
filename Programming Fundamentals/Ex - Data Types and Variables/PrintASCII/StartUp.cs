namespace PrintASCII
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            int firstInputLine = int.Parse(Console.ReadLine());
            int secoundInputLine = int.Parse(Console.ReadLine());

            for (int i = firstInputLine; i <= secoundInputLine; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
