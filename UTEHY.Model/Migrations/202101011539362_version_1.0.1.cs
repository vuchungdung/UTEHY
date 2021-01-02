namespace UTEHY.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_101 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        CreateBy = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FacultyId);
            
            CreateTable(
                "dbo.TemplateInFaculties",
                c => new
                    {
                        FacultyId = c.String(nullable: false, maxLength: 128),
                        TemplateId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FacultyId, t.TemplateId });
            
            CreateTable(
                "dbo.Templates",
                c => new
                    {
                        TemplateId = c.String(nullable: false, maxLength: 128),
                        Path = c.String(),
                        CreateBy = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TemplateId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Templates");
            DropTable("dbo.TemplateInFaculties");
            DropTable("dbo.Faculties");
        }
    }
}
