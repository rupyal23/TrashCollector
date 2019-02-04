namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TC11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pickups", "Day", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pickups", "Day", c => c.Int(nullable: false));
        }
    }
}
