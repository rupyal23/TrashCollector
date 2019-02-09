namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedValidationAttForPickUpDAte : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pickups", "PickupDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pickups", "PickupDate", c => c.DateTime(nullable: false));
        }
    }
}
