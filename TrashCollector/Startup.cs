using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TrashCollector.Models;

[assembly: OwinStartupAttribute(typeof(TrashCollector.Startup))]
namespace TrashCollector
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            ////create new role -Admin
            //if(!roleManager.RoleExists("Admin"))
            //{
            //    roleManager.Create(new IdentityRole("Admin"));

            //    //After creating admin role, creating admin user
            //    var user = new ApplicationUser();
            //    user.UserName = "rupyal";
            //    user.Email = "rupyal@trashcollector.com";

            //    string userPWD = "Test@123";

            //    var chkUser = userManager.Create(user, userPWD);
            //    //Add this user to Admin role
            //    if(chkUser.Succeeded)
            //    {
            //        var result1 = userManager.AddToRole(user.Id, "Admin");
            //    }
            //}

            // creating Customer Role
            if(!roleManager.RoleExists("Customer"))
            {
                roleManager.Create(new IdentityRole("Customer"));
            }
            // create Employee Role
            if(!roleManager.RoleExists("Employee"))
            {
                roleManager.Create(new IdentityRole("Employee"));
            }
        }
    }
}
