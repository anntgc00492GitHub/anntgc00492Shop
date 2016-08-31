namespace anntgc00492Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChinhLaiTruongError : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Errors", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Errors", "CreatedDate", c => c.String());
        }
    }
}
