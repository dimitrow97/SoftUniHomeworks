namespace _7_Add_Default_Age.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgeAndSetDefaultValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("Customers", "Age", a => a.Int(defaultValue: 20));
        }
        
        public override void Down()
        {
            DropColumn("Customers", "Age");
        }
    }
}
