namespace _6_Customers_Migration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstLastNameColumsToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("Customers", "FirstName", w => w.String());    
            AddColumn("Customers", "LastName", w => w.String());
            DropColumn("Customers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("Customers", "Name", w => w.String());
            DropColumn("Customers", "LastName");
            DropColumn("Customers", "FirstName");
        }
    }
}
