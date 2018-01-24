namespace _7_Add_Default_Age.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_7_Add_Default_Age.SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_7_Add_Default_Age.SalesContext context)
        {
            context.Products.AddOrUpdate(new Product() { Name = "Sugar", Description = "Sweet Sugar", Price = 2.00M, Quantity = 10 });
            context.Customers.AddOrUpdate(new Customer() { FirstName = "Teo", LastName = "Georgiev", CreditCardNumber = "3213123dasda3", Email = "teo@gmail.com" });
        }
    }
}
