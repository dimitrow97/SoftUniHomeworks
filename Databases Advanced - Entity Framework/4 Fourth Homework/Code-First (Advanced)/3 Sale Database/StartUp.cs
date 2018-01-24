using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Sale_Database
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Product sugar = new Product();
            sugar.Name = "Sugar";
            sugar.Price = 2.00M;
            sugar.Quantity = 10;

            Product ham = new Product();
            ham.Name = "Ham";
            ham.Price = 5.00M;
            ham.Quantity = 5;

            Product milk = new Product();
            milk.Name = "Milk";
            milk.Price = 3.50M;
            milk.Quantity = 7;

            Customer ivan = new Customer();
            ivan.Name = "Ivan";
            ivan.Email = "ivan@gmail.com";
            ivan.CreditCardNumber = "dawdwadaw3213";

            Customer maria = new Customer();
            maria.Name = "Maria";
            maria.Email = "maria@yahoo.com";
            maria.CreditCardNumber = "dawdbvdaw3213";

            Customer asen = new Customer();
            asen.Name = "Asen";
            asen.Email = "asen@gmail.com";
            asen.CreditCardNumber = "qwertyasd4112";

            StoreLocation sliven = new StoreLocation();
            sliven.LocationName = "Sliven";

            StoreLocation sofia = new StoreLocation();
            sofia.LocationName = "sofia";

            Sale sugarSale = new Sale();
            sugarSale.Product = sugar;
            sugarSale.Customer = maria;
            sugarSale.StoreLocation = sliven;
            sugarSale.Date = DateTime.Now;

            Sale hamSale = new Sale();
            hamSale.Product = ham;
            hamSale.Customer = ivan;
            hamSale.StoreLocation = sliven;
            hamSale.Date = DateTime.Now;

            Sale milkSale = new Sale();
            milkSale.Product = milk;
            milkSale.Customer = asen;
            milkSale.StoreLocation = sofia;
            milkSale.Date = DateTime.Now;

            SalesContext context = new SalesContext();

            context.Sales.Add(sugarSale);
            context.Sales.Add(hamSale);
            context.Sales.Add(milkSale);

            context.SaveChanges();
        }
    }
}
