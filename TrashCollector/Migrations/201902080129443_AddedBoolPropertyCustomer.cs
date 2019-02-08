namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBoolPropertyCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ExtraPickupRequest", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ExtraPickupRequest");
        }
    }
}
