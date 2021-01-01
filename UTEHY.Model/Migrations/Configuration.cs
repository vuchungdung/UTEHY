namespace UTEHY.Model.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UTEHY.Model.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<UTEHY.Model.Entities.FITDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UTEHY.Model.Entities.FITDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            CreateUser(context);
        }
        private void CreateUser(FITDbContext context)
        {
            var manager = new UserManager<User>(new UserStore<User>(new FITDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new FITDbContext()));

            var user = new User()
            {
                UserName = "khoacntt",
                Email = "fit@utehy.edu.vn",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Khoa công nghệ thông tin"
            };
            if (manager.Users.Count(x => x.UserName == "khoacntt") == 0)
            {
                manager.Create(user, "123654$");

                roleManager.Create(new IdentityRole { Name = "Faculty" });

                var adminUser = manager.FindByEmail("fit@utehy.edu.vn");

                manager.AddToRoles(adminUser.Id, new string[] { "Faculty" });
            }

        }
    }
}
