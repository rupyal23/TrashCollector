namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedSecondpickupFromPickup : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pickups", "SecondPickupDate");
            DropColumn("dbo.Pickups", "SecondPickupDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pickups", "SecondPickupDay", c => c.Int());
            AddColumn("dbo.Pickups", "SecondPickupDate", c => c.DateTime());
        }
    }
}
