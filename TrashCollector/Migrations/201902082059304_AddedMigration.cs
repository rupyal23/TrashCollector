namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pickups", "PickupDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pickups", "PickupDate", c => c.DateTime());
        }
    }
}
