namespace UTEHY.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_105 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetRoles", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetRoles", "Description", c => c.String());
        }
    }
}
