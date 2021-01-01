namespace UTEHY.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_100 : DbMigration
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
                        Status = c.Boolean(nullable: false),
                        Email = c.String(),
                        UserName = c.String(maxLength: 100),
                        FacultyId = c.String(),
                        CreateBy = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        Deleted = c.Boolean(nullable: false),
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
                        FacultyId = c.String(),
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
                        DisplayOrder = c.Int(),
                        FacultyId = c.String(),
                        CreateBy = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        Deleted = c.Boolean(nullable: false),
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
                        Img = c.String(),
                        Status = c.Int(nullable: false),
                        MoreImgs = c.String(),
                        FacultyId = c.String(),
                        CreateBy = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                        FacultyId = c.String(),
                        CreateBy = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        Deleted = c.Boolean(nullable: false),
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
                        FacultyId = c.String(),
                        CreateBy = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TecherId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(maxLength: 256),
                        Address = c.String(maxLength: 256),
                        BirthDay = c.DateTime(),
                        Img = c.String(),
                        FacultyId = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Posts", new[] { "Name" });
            DropIndex("dbo.PostCategories", new[] { "Name" });
            DropIndex("dbo.Menus", new[] { "Name" });
            DropIndex("dbo.Functions", new[] { "Name" });
            DropIndex("dbo.Commands", new[] { "Name" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Teachers");
            DropTable("dbo.Slides");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Posts");
            DropTable("dbo.PostCategories");
            DropTable("dbo.Permissions");
            DropTable("dbo.Menus");
            DropTable("dbo.Functions");
            DropTable("dbo.Footers");
            DropTable("dbo.Comments");
            DropTable("dbo.Commands");
            DropTable("dbo.CommandInFunctions");
        }
    }
}
