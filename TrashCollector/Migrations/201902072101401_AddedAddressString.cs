namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAddressString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "AddressString_Capacity", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "AddressString_Length", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "AddressString_Length");
            DropColumn("dbo.Addresses", "AddressString_Capacity");
        }
    }
}
