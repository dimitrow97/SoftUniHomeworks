namespace RefactorVPyramid
{
    using System;

    class StartUp
    {
        public static void Main(string[] args)
        {
            double length, width, heigth, volume = 0;
            Console.Write("Length: ");
            length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            heigth = double.Parse(Console.ReadLine());

            volume = (length * heigth * width) / 3;

            Console.WriteLine($"Pyramid Volume: {volume:F2}");
        }
    }
}
