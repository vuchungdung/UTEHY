namespace UTEHY.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_109 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "MenuId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "MenuId");
            DropColumn("dbo.Menus", "CreateDate");
        }
    }
}
