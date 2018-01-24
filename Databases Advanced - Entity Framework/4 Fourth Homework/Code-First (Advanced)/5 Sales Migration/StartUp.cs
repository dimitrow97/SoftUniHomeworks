using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Sales_Migration
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
