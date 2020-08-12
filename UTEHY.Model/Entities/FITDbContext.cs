using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.Entities
{
    public class FITDbContext : IdentityDbContext<User>
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
        public DbSet<CommandInFunction> CommandInFunctions { set; get; }
        public static FITDbContext Create()
        {
            return new FITDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

    