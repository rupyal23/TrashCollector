namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPickupIdFKInCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickupId", c => c.Int());
            CreateIndex("dbo.Customers", "PickupId");
            AddForeignKey("dbo.Customers", "PickupId", "dbo.Pickups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "PickupId", "dbo.Pickups");
            DropIndex("dbo.Customers", new[] { "PickupId" });
            DropColumn("dbo.Customers", "PickupId");
        }
    }
}
