namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeDateTimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pickups", "SecondPickupDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pickups", "SecondPickupDate", c => c.DateTime(nullable: false));
        }
    }
}
