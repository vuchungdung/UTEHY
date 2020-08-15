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
            //  CreateUser(context);
        }
        private void CreateUser(FITDbContext context)
        {
            var manager = new UserManager<User>(new UserStore<User>(new FITDbContext()));

            var roleManager = new RoleManager<Role>(new RoleStore<Role>(new FITDbContext()));

            var user = new User()
            {
                UserName = "trungtampm",
                Email = "trungtamphanmem@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Trung tâm phần mềm"

            };
            if (manager.Users.Count(x => x.UserName == "trungtampm") == 0)
            {
                manager.Create(user, "123654$");

                if (!roleManager.Roles.Any())
                {
                    roleManager.Create(new Role { Name = "Admin",Description="Nhóm quyền Admin" });
                    roleManager.Create(new Role { Name = "Editor",Description="Nhóm quyền Editor" });
                }

                var adminUser = manager.FindByEmail("trungtamphanmem@gmail.com");

                manager.AddToRoles(adminUser.Id, new string[] { "Admin", "Editor" });
            }

        }
    }
}