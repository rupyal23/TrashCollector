namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStatusPropInPickup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pickups", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pickups", "Status");
        }
    }
}
