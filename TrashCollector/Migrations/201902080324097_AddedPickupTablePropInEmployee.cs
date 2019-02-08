namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPickupTablePropInEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pickups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PickUpDay = c.DateTime(),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "PickupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "PickupId");
            AddForeignKey("dbo.Employees", "PickupId", "dbo.Pickups", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "PickupId", "dbo.Pickups");
            DropIndex("dbo.Employees", new[] { "PickupId" });
            DropColumn("dbo.Employees", "PickupId");
            DropTable("dbo.Pickups");
        }
    }
}
