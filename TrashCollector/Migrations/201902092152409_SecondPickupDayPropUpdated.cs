namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondPickupDayPropUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pickups", "SecondPickupDay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pickups", "SecondPickupDay", c => c.String());
        }
    }
}
