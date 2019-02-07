namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAddressString : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Addresses", "AddressString_Capacity");
            DropColumn("dbo.Addresses", "AddressString_Length");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "AddressString_Length", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "AddressString_Capacity", c => c.Int(nullable: false));
        }
    }
}
