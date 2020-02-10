namespace MVC_BierenWebAplli.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVC_BierenWebAplli.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_BierenWebAplli.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVC_BierenWebAplli.Models.ApplicationDbContext";
        }

        protected override void Seed(MVC_BierenWebAplli.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "Admin@MVC.net"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var user = new ApplicationUser { UserName = "Admin@MVC.net" };
                userManager.Create(user, "Admin0");
                var role = new IdentityRole { Name = "Administrators" };
                roleManager.Create(role);
                userManager.AddToRole(user.Id, "Administrators");
            }
        }
    }
}
