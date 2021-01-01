namespace UTEHY.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_102 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Templates", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Templates", "Image");
        }
    }
}
