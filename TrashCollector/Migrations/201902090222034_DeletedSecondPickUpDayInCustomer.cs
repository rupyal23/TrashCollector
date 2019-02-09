namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedSecondPickUpDayInCustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "SecondPickUpDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "SecondPickUpDay", c => c.DateTime());
        }
    }
}
