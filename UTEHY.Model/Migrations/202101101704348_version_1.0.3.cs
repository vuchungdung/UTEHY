namespace UTEHY.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_103 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faculties", "TemplateId", c => c.String());
            AddColumn("dbo.AspNetUsers", "CreateBy", c => c.Int());
            AddColumn("dbo.AspNetUsers", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "UpdateBy", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Deleted", c => c.Boolean(nullable: false));
            DropTable("dbo.TemplateInFaculties");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TemplateInFaculties",
                c => new
                    {
                        FacultyId = c.String(nullable: false, maxLength: 128),
                        TemplateId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FacultyId, t.TemplateId });
            
            DropColumn("dbo.AspNetUsers", "Deleted");
            DropColumn("dbo.AspNetUsers", "UpdateBy");
            DropColumn("dbo.AspNetUsers", "UpdateDate");
            DropColumn("dbo.AspNetUsers", "CreateDate");
            DropColumn("dbo.AspNetUsers", "CreateBy");
            DropColumn("dbo.Faculties", "TemplateId");
        }
    }
}
