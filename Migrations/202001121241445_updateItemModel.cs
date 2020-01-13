namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateItemModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Item", "CId_Id", c => c.Int());
            CreateIndex("dbo.Item", "CId_Id");
            AddForeignKey("dbo.Item", "CId_Id", "dbo.Category", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "CId_Id", "dbo.Category");
            DropIndex("dbo.Item", new[] { "CId_Id" });
            DropColumn("dbo.Item", "CId_Id");
            DropTable("dbo.Category");
        }
    }
}
