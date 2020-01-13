namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTwoPropertiesInUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "MobileNo", c => c.Long(nullable: false));
            AddColumn("dbo.User", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Address");
            DropColumn("dbo.User", "MobileNo");
        }
    }
}
