using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Seed_Some_Data_in_the_Database
{
    class StartUp
    {
        static void Main(string[] args)
        {
            StudentContext context = new StudentContext();
            Console.WriteLine(context.Students.Count());        
        }
    }
}
