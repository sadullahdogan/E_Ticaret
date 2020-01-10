using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_Ticaret_WEBUI.Identity
{
    public class IdentityInitalizer:CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            //Roller
            if (!context.Roles.Any(x => x.Name == "admin")) {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Decsription = "Admin Role" };
                manager.Create(role);
                
            }
            if (!context.Roles.Any(x => x.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Decsription = "User Role" };
                manager.Create(role);

            }
            if (!context.Roles.Any(x => x.Name == "visitor"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "visitor", Decsription = "Visitor Role" };
                manager.Create(role);

            }

            //user

            if (!context.Users.Any(x => x.Name == "Sadullah"))
            {
                var store = new UserStore<ApplicationUsers>(context);
                var manager = new UserManager<ApplicationUsers>(store);
                var user = new ApplicationUsers() { Name = "Sadullah",Surname="Doğan",Email="sado.doan@gmail.com",EmailConfirmed=true,UserName="sadullah"};
                manager.Create(user, "12345678");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }

            base.Seed(context);
        }
    }
}