namespace anntgc00492Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chinhlaidb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CustomerId", c => c.String(maxLength: 128));
            AddColumn("dbo.Orders", "CustomerMobile", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Orders", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "Tags", c => c.String());
            AddColumn("dbo.Products", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Products", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Products", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Products", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Products", "MetaKeyword", c => c.String(maxLength: 256));
            AddColumn("dbo.Products", "MetaDescription", c => c.String(maxLength: 256));
            AddColumn("dbo.Products", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "CusotmerMobile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CusotmerMobile", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Products", "Status");
            DropColumn("dbo.Products", "MetaDescription");
            DropColumn("dbo.Products", "MetaKeyword");
            DropColumn("dbo.Products", "UpdatedBy");
            DropColumn("dbo.Products", "UpdatedDate");
            DropColumn("dbo.Products", "CreatedBy");
            DropColumn("dbo.Products", "CreatedDate");
            DropColumn("dbo.Products", "Tags");
            DropColumn("dbo.Orders", "Status");
            DropColumn("dbo.Orders", "CustomerMobile");
            DropColumn("dbo.Orders", "CustomerId");
        }
    }
}
