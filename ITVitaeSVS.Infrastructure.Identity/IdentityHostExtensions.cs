using ITVitaeSVS.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Infrastructure.Identity {
    public static class IdentityHostExtensions {
        public static IHost InitializeIdentity(this IHost host) {
            using (var scope = host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                try {
                    var context = services.GetRequiredService<IdentityDbContext>();
                    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    context.Database.Migrate();
                    SeedRoles(roleManager);
                    SeedUsers(userManager);
                } catch (Exception ex) {
                    throw;
                }
            }
            return host;
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager) {
            if(userManager.FindByEmailAsync("admin@admin.com").Result == null) {
                var user = new IdentityUser() {
                    Email = "admin@admin.com",
                    UserName = "admin@admin.com",
                    EmailConfirmed = true
                };
                var result = userManager.CreateAsync(user, "Password123!").Result;
                if(result.Succeeded) {
                    userManager.AddToRoleAsync(user, Roles.Admin).Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager) {
            if(!roleManager.RoleExistsAsync(Roles.Admin).Result) {
                var role = new IdentityRole(Roles.Admin);
                roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
