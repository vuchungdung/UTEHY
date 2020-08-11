namespace UTEHY.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class repairdDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommandInFunctions",
                c => new
                    {
                        CommandId = c.String(nullable: false, maxLength: 128),
                        FunctionId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CommandId, t.FunctionId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CommandInFunctions");
        }
    }
}
