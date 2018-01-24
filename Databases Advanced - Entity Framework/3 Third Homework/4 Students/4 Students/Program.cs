using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while(input != "End")
            {
                Student st = new Student(input);
                input = Console.ReadLine();
            }

            Console.WriteLine(Student.count);
        }
    }
}
