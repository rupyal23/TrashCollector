namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCustomerIdinPickup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "PickupId", "dbo.Pickups");
            DropIndex("dbo.Customers", new[] { "PickupId" });
            AddColumn("dbo.Pickups", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pickups", "CustomerId");
            AddForeignKey("dbo.Pickups", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "PickupId");
            DropColumn("dbo.Customers", "PickUpDay");
            DropColumn("dbo.Pickups", "Zip");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pickups", "Zip", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "PickUpDay", c => c.DateTime());
            AddColumn("dbo.Customers", "PickupId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Pickups", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Pickups", new[] { "CustomerId" });
            DropColumn("dbo.Pickups", "CustomerId");
            CreateIndex("dbo.Customers", "PickupId");
            AddForeignKey("dbo.Customers", "PickupId", "dbo.Pickups", "Id", cascadeDelete: true);
        }
    }
}
