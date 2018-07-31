namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reviews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "Product_ID", c => c.Int());
            CreateIndex("dbo.Reviews", "Product_ID");
            AddForeignKey("dbo.Reviews", "Product_ID", "dbo.Products", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Product_ID", "dbo.Products");
            DropIndex("dbo.Reviews", new[] { "Product_ID" });
            DropColumn("dbo.Reviews", "Product_ID");
        }
    }
}
