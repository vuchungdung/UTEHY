using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.Entities
{
    public class FITDbContext : IdentityDbContext<ApplicationUser>
    {
        public FITDbContext() : base("FITConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Footer> Footers { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<Slide> Slides { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DbSet<Function> Functions { set; get; }
        public DbSet<Permission> Permissions { set; get; }
        public DbSet<Teacher> Teachers { set; get; }
        public DbSet<Command> Commands { set; get; }

        public DbSet<ApplicationRole> ApplicationRoles { set; get; }
        public DbSet<ApplicationUser> ApplicationUsers { set; get; }
        public static FITDbContext Create()
        {
            return new FITDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");
            builder.Entity<IdentityUser>().ToTable("ApplicationUsers");
        }
    }
}
