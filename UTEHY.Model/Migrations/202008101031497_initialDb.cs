namespace UTEHY.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(maxLength: 250),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.ApplicationRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Commands",
                c => new
                    {
                        CommandId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.CommandId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.String(nullable: false, maxLength: 128),
                        Content = c.String(),
                        PostId = c.String(maxLength: 128),
                        ReplyId = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        Email = c.String(),
                        UserName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.CommentId);
            
            CreateTable(
                "dbo.Footers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Functions",
                c => new
                    {
                        FunctionId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 100),
                        Url = c.String(),
                        SortOrder = c.Int(),
                        ParentId = c.String(maxLength: 128),
                        Icons = c.String(),
                    })
                .PrimaryKey(t => t.FunctionId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 100),
                        URL = c.String(),
                        DisplayOrder = c.Int(),
                        Status = c.Boolean(nullable: false),
                        ParentId = c.String(maxLength: 128),
                        Content = c.String(),
                        PostId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MenuId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        FunctionId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        CommandId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FunctionId, t.RoleId, t.CommandId });
            
            CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        CategoryId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 256),
                        Alias = c.String(maxLength: 256),
                        ParentId = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 256),
                        Alias = c.String(maxLength: 256),
                        CategoryId = c.String(maxLength: 128),
                        Description = c.String(),
                        Content = c.String(),
                        HomeFlag = c.Boolean(),
                        ViewCount = c.Int(),
                        LikeCount = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        Img = c.String(),
                        Status = c.Int(nullable: false),
                        MoreImgs = c.String(),
                    })
                .PrimaryKey(t => t.PostId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        SlideId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Img = c.String(),
                        Url = c.String(),
                        DisplayOrder = c.Int(),
                        Status = c.Boolean(nullable: false),
                        ImgType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SlideId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TecherId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Position = c.String(),
                        WorkPlace = c.String(),
                        WebSite = c.String(),
                        Content = c.String(),
                        Img = c.String(),
                    })
                .PrimaryKey(t => t.TecherId);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(maxLength: 256),
                        Address = c.String(maxLength: 256),
                        BirthDay = c.DateTime(),
                        Img = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserRoles", "IdentityRole_Id", "dbo.ApplicationRoles");
            DropIndex("dbo.ApplicationUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Posts", new[] { "Name" });
            DropIndex("dbo.PostCategories", new[] { "Name" });
            DropIndex("dbo.Menus", new[] { "Name" });
            DropIndex("dbo.Functions", new[] { "Name" });
            DropIndex("dbo.Commands", new[] { "Name" });
            DropIndex("dbo.ApplicationUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserRoles", new[] { "IdentityRole_Id" });
            DropTable("dbo.ApplicationUserLogins");
            DropTable("dbo.ApplicationUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.Teachers");
            DropTable("dbo.Slides");
            DropTable("dbo.Posts");
            DropTable("dbo.PostCategories");
            DropTable("dbo.Permissions");
            DropTable("dbo.Menus");
            DropTable("dbo.Functions");
            DropTable("dbo.Footers");
            DropTable("dbo.Comments");
            DropTable("dbo.Commands");
            DropTable("dbo.ApplicationUserRoles");
            DropTable("dbo.ApplicationRoles");
        }
    }
}
