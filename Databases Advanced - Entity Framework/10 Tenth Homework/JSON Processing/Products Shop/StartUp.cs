using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Shop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ShopContext context = new ShopContext();
            context.Database.Initialize(force: true);
        }
    }
}
