namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPropinPickup : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pickups", "PickupDay", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pickups", "PickupDay", c => c.Int());
        }
    }
}
