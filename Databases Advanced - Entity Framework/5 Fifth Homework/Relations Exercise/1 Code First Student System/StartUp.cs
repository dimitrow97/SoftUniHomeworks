using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Code_First_Student_System
{
    class StartUp
    {
        static void Main(string[] args)
        {
            StudentsContext context = new StudentsContext();
            context.Database.Initialize(force: true);
        }
    }
}
