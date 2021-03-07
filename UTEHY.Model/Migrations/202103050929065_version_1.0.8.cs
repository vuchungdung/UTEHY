namespace UTEHY.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_108 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "HotFlag", c => c.Boolean());
            DropColumn("dbo.Posts", "ViewCount");
            DropColumn("dbo.Posts", "LikeCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "LikeCount", c => c.Int());
            AddColumn("dbo.Posts", "ViewCount", c => c.Int());
            DropColumn("dbo.Posts", "HotFlag");
        }
    }
}
