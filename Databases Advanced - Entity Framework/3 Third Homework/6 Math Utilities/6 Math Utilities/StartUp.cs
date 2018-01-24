using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Math_Utilities
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            while(input[0] != "End")
            {
                if (input[0] == "Sum")
                    Console.WriteLine($"{MathUtil.Sum(double.Parse(input[1]), double.Parse(input[2])):f2}");
                if (input[0] == "Subtract")
                    Console.WriteLine($"{MathUtil.Sub(double.Parse(input[1]), double.Parse(input[2])):f2}");
                if (input[0] == "Multiply")
                    Console.WriteLine($"{MathUtil.Multiply(double.Parse(input[1]), double.Parse(input[2])):f2}");
                if (input[0] == "Percentage")
                    Console.WriteLine($"{MathUtil.Percentage(double.Parse(input[1]), double.Parse(input[2])):f2}");
                if (input[0] == "Divide")
                    Console.WriteLine($"{MathUtil.Div(double.Parse(input[1]), double.Parse(input[2])):f2}");

                input = Console.ReadLine().Split(' ');
            }
        }
    }
}
