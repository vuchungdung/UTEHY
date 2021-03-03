namespace UTEHY.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_106 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PostCategories", "DisplayOrder");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostCategories", "DisplayOrder", c => c.Int());
        }
    }
}
