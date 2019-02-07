namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedApplicationUserIdInCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "AppicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "AppicationUserId");
            AddForeignKey("dbo.Customers", "AppicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "AppicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "AppicationUserId" });
            DropColumn("dbo.Customers", "AppicationUserId");
        }
    }
}
