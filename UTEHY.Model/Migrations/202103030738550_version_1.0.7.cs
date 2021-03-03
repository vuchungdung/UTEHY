namespace UTEHY.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_107 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PostCategories", "FacultyId", c => c.String(maxLength: 128));
            DropColumn("dbo.PostCategories", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostCategories", "ParentId", c => c.String(maxLength: 128));
            AlterColumn("dbo.PostCategories", "FacultyId", c => c.String());
        }
    }
}
