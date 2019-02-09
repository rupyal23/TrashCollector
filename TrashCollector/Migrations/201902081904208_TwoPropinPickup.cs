namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TwoPropinPickup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pickups", "SecondPickupDate", c => c.DateTime());
            AddColumn("dbo.Pickups", "SecondPickupDay", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pickups", "SecondPickupDay");
            DropColumn("dbo.Pickups", "SecondPickupDate");
        }
    }
}
