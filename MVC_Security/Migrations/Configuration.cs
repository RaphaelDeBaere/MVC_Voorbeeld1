namespace MVC_Security.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVC_Security.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Security.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVC_Security.Models.ApplicationDbContext";
        }

        protected override void Seed(MVC_Security.Models.ApplicationDbContext context)
        {
            // This method will be called after migrating to the latest version.
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            ApplicationUser user;
            if (!context.Roles.Any(u => u.Name == "Student"))
                roleManager.Create(new IdentityRole { Name = "Student" });
            if (!context.Roles.Any(u => u.Name == "Leraar"))
                roleManager.Create(new IdentityRole { Name = "Leraar" });

            if (!context.Roles.Any(u => u.Name == "Admin"))
                roleManager.Create(new IdentityRole { Name = "Admin" });
            if (!context.Users.Any(u => u.UserName == "Admin@mvc.net"))
            {
                user = new ApplicationUser { UserName = "Admin@mvc.net" };
                userManager.Create(user, "Admin0");
                userManager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "Leraar1@mvc.net"))
            {
                user = new ApplicationUser { UserName = "Leraar1@mvc.net" };
                userManager.Create(user, "Leraar1");
                userManager.AddToRole(user.Id, "Leraar");
            }
            if (!context.Users.Any(u => u.UserName == "Leraar2@mvc.net"))
            {
                user = new ApplicationUser { UserName = "Leraar2@mvc.net" };
                userManager.Create(user, "Leraar2");
                userManager.AddToRole(user.Id, "Leraar");
            }
            if (!context.Users.Any(u => u.UserName == "Leraar3@mvc.net"))
            {
                user = new ApplicationUser { UserName = "Leraar3@mvc.net" };
                userManager.Create(user, "Leraar3");
                userManager.AddToRole(user.Id, "Leraar");
            }
            if (!context.Users.Any(u => u.UserName == "Student1@mvc.net"))
            {
                user = new ApplicationUser { UserName = "Student1@mvc.net" };
                userManager.Create(user, "Student1");
                userManager.AddToRole(user.Id, "Student");
            }
            if (!context.Users.Any(u => u.UserName == "Student2@mvc.net"))
            {
                user = new ApplicationUser { UserName = "Student2@mvc.net" };
                userManager.Create(user, "Student2");
                userManager.AddToRole(user.Id, "Student");
            }
            if (!context.Users.Any(u => u.UserName == "Student3@mvc.net"))
            {
                user = new ApplicationUser { UserName = "Student3@mvc.net" };
                userManager.Create(user, "Student3");
                userManager.AddToRole(user.Id, "Student");
            }
            if (!context.Users.Any(u => u.UserName == "Student4@mvc.net"))
            {
                user = new ApplicationUser { UserName = "Student4@mvc.net" };
                userManager.Create(user, "Student4");
                userManager.AddToRole(user.Id, "Student");
            }
        }
    }
}
