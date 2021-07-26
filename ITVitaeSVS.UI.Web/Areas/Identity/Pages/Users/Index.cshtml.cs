using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ITVitaeSVS.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITVitaeSVS.UI.Web.Areas.Identity.Pages.Users
{
    [Authorize(Policy = Permissions.ManageUsers)]
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityUser> roleManager;

        public IEnumerable<UserViewModel> Users { get; set; }

        public IndexModel(UserManager<IdentityUser> userManager,
            RoleManager<IdentityUser> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public void OnGet()
        {
            Users = userManager.Users.ToList().Select(user => new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Claims = userManager.GetClaimsAsync(user).Result,
            });
        }

        public class UserViewModel
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public IEnumerable<Claim> Claims { get; set; }
        }
    }
}
