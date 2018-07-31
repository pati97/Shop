namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShopProducts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.Reviews", "Product_ID", "dbo.Products");
            DropIndex("dbo.Products", new[] { "Category_ID" });
            DropIndex("dbo.Reviews", new[] { "Product_ID" });
            DropColumn("dbo.Products", "Category_ID");
            DropColumn("dbo.Reviews", "Product_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "Product_ID", c => c.Int());
            AddColumn("dbo.Products", "Category_ID", c => c.Int());
            CreateIndex("dbo.Reviews", "Product_ID");
            CreateIndex("dbo.Products", "Category_ID");
            AddForeignKey("dbo.Reviews", "Product_ID", "dbo.Products", "ID");
            AddForeignKey("dbo.Products", "Category_ID", "dbo.Categories", "ID");
        }
    }
}
