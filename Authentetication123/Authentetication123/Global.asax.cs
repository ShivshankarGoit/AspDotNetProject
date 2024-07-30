using Authentetication123.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Authentetication123
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CreateRoles();
        }

        public void CreateRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            if (!roleManager.RoleExists("OwnerName"))
            {
                var role = new IdentityRole("OwnerName");
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("EmployeeName"))
            {
                var role = new IdentityRole("EmployeeName");
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("UserName"))
            {
                var role = new IdentityRole("UserName");
                roleManager.Create(role);
            }
        }
    }
}
