namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added2PropForPickupsInCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SecondPickUpDay", c => c.DateTime());
            AddColumn("dbo.Customers", "TotalPickups", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "TotalPickups");
            DropColumn("dbo.Customers", "SecondPickUpDay");
        }
    }
}
