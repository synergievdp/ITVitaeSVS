using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using ITVitaeSVS.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITVitaeSVS.UI.Web.Areas.Identity.Pages.Users
{
    [Authorize(Policy = Permissions.ManageUsers)]
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public ICollection<UserViewModel> Users { get; set; }

        public IndexModel(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public void OnGet()
        {
            Users = new List<UserViewModel>();
            foreach(var user in userManager.Users.ToList())
            {
                var userVM = new UserViewModel() { Id = user.Id, Email = user.Email };
                foreach (var role in roleManager.Roles.ToList())
                    if (userManager.IsInRoleAsync(user, role.Name).Result)
                        userVM.Roles.Add(role);
                Users.Add(userVM);
            }
        }

        public class UserViewModel
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public ICollection<IdentityRole> Roles { get; set; } = new List<IdentityRole>();
        }
    }
}
