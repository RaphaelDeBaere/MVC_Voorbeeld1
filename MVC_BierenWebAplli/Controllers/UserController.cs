using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_BierenWebAplli.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace MVC_BierenWebAplli.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Userbeheer()
        {
            IDbSet<ApplicationUser> alleUsers = context.Users;
            return View(alleUsers);
        }
        public ActionResult Rolebeheer()
        {
            IDbSet<IdentityRole> alleRoles = context.Roles;
            return View(alleRoles);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}