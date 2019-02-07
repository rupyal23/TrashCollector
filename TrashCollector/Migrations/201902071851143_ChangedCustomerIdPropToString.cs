namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCustomerIdPropToString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "NextPickupId", "dbo.Pickups");
            DropIndex("dbo.Customers", new[] { "NextPickupId" });
            AddColumn("dbo.Customers", "PickUpDay", c => c.DateTime());
            AlterColumn("dbo.Customers", "SuspendStartDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "SuspendEndDate", c => c.DateTime());
            DropColumn("dbo.Customers", "NextPickupId");
            DropTable("dbo.Pickups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pickups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Zip = c.Int(nullable: false),
                        Day = c.String(),
                        Time = c.DateTime(nullable: false),
                        NumberOfPickups = c.Int(nullable: false),
                        PickUpStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "NextPickupId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "SuspendEndDate", c => c.String());
            AlterColumn("dbo.Customers", "SuspendStartDate", c => c.String());
            DropColumn("dbo.Customers", "PickUpDay");
            CreateIndex("dbo.Customers", "NextPickupId");
            AddForeignKey("dbo.Customers", "NextPickupId", "dbo.Pickups", "Id", cascadeDelete: true);
        }
    }
}
