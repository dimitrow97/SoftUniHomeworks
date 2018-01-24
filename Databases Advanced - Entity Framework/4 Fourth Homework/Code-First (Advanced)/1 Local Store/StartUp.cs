using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Local_Store
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Product sugar = new Product("Sugar", "Sweetness OOD", "1kg of Sugar", 2.00M);
            Product ham = new Product("Ham", "Meat Delivery OOD", "250gr of Ham", 3.50M);
            Product cola = new Product("Coca Cola", "Coca Cola OOD", "2l of Cola", 2.20M);

            ProductsContext context = new ProductsContext();

            context.Products.Add(sugar);
            context.Products.Add(ham);
            context.Products.Add(cola);

            context.SaveChanges();
        }
    }
}
