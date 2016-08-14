namespace anntgc00492Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdb1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Menu", newName: "Menus");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Menus", newName: "Menu");
        }
    }
}
