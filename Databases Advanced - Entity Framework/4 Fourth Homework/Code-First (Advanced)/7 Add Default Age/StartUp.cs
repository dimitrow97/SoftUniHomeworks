using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Add_Default_Age
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SalesContext context = new SalesContext();
            context.Database.Initialize(force: true);    
        }
    }
}
