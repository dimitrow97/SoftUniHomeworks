namespace _5_Sales_Migration
{
    
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SalesContext : DbContext
    {
        public SalesContext() : base("name=SalesContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SalesContext>());
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<StoreLocation> Stores { get; set; }
    }
}