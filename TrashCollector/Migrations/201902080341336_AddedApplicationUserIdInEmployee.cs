namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedApplicationUserIdInEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "AppicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "AppicationUserId");
            AddForeignKey("dbo.Employees", "AppicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "AppicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "AppicationUserId" });
            DropColumn("dbo.Employees", "AppicationUserId");
        }
    }
}
