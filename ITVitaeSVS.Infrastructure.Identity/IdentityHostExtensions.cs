using ITVitaeSVS.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
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
            if(userManager.FindByEmailAsync("admin@test.com").Result == null) {
                var user = new IdentityUser() {
                    Email = "admin@test.com",
                    UserName = "admin@test.com",
                    EmailConfirmed = true
                };
                var result = userManager.CreateAsync(user, "Password123!").Result;
                if(result.Succeeded) {
                    userManager.AddToRoleAsync(user, Roles.Admin).Wait();
                }
            }

            if (userManager.FindByEmailAsync("teacher@test.com").Result == null)
            {
                var user = new IdentityUser()
                {
                    Email = "teacher@test.com",
                    UserName = "teacher@test.com",
                    EmailConfirmed = true
                };
                var result = userManager.CreateAsync(user, "Password123!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Roles.Teacher).Wait();
                }
            }

            if (userManager.FindByEmailAsync("student@test.com").Result == null)
            {
                var user = new IdentityUser()
                {
                    Email = "student@test.com",
                    UserName = "student@test.com",
                    EmailConfirmed = true
                };
                var result = userManager.CreateAsync(user, "Password123!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Roles.Student).Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager) {

            if (!roleManager.RoleExistsAsync(Roles.Admin).Result)
            {
                var role = new IdentityRole(Roles.Admin);
                roleManager.CreateAsync(role).Wait();
            }

            var admin = roleManager.FindByNameAsync(Roles.Admin).Result;
            if (admin != null)
            {
                roleManager.AddPermission(admin, Permissions.ManageUsers);
                roleManager.AddPermission(admin, Permissions.ManageStudents);
                roleManager.AddPermission(admin, Permissions.ManageContent);
                roleManager.AddPermission(admin, Permissions.ViewTopics);
            }

            if (!roleManager.RoleExistsAsync(Roles.Teacher).Result)
            {
                var role = new IdentityRole(Roles.Teacher);
                roleManager.CreateAsync(role).Wait();
            }
            var teacher = roleManager.FindByNameAsync(Roles.Teacher).Result;
            if (teacher != null)
            {
                roleManager.AddPermission(teacher, Permissions.ManageStudents);
                roleManager.AddPermission(teacher, Permissions.ManageContent);
                roleManager.AddPermission(teacher, Permissions.ViewTopics);
            }

            if (!roleManager.RoleExistsAsync(Roles.Student).Result)
            {
                var role = new IdentityRole(Roles.Student);
                roleManager.CreateAsync(role).Wait();
            }
            var student = roleManager.FindByNameAsync(Roles.Student).Result;
            if(student != null)
            {
                roleManager.AddPermission(student, Permissions.ViewTopics);
            }
        }

        private static void AddPermission(this RoleManager<IdentityRole> roleManager, IdentityRole role, string value)
        {
            var claims = roleManager.GetClaimsAsync(role).Result;
            if (!claims.Any(claim => claim.Type == Permissions.ClaimType
                && claim.Value == value))
            {
                roleManager.AddClaimAsync(role, new Claim(Permissions.ClaimType, value)).Wait();
            }
            
        }
    }
}
