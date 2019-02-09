namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropinPickup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pickups", "SecondPickupDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Pickups", "SecondPickupDay", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pickups", "SecondPickupDay");
            DropColumn("dbo.Pickups", "SecondPickupDate");
        }
    }
}
