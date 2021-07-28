using ITVitaeSVS.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Infrastructure.Identity {
    public static class IdentityServiceExtensions {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration config) {
            services.AddDbContext<IdentityDbContext>(
                options =>
                    options.UseSqlServer(config.GetConnectionString("IdentityDbContext"),
                    builder => 
                        builder.MigrationsAssembly(typeof(IdentityDbContext).Assembly.FullName))
            );

            services.AddAuthorization(options => {
                options.AddPolicy(Permissions.ManageContent, policy => policy.RequireClaim(Permissions.ClaimType, Permissions.ManageContent));
                options.AddPolicy(Permissions.ManageStudents, policy => policy.RequireClaim(Permissions.ClaimType, Permissions.ManageStudents));
                options.AddPolicy(Permissions.ManageUsers, policy => policy.RequireClaim(Permissions.ClaimType, Permissions.ManageUsers));
                options.AddPolicy(Permissions.ChangeProgress, policy => policy.Requirements.Add(new ChangeProgressRequirement()));
                options.AddPolicy(Permissions.ViewTopics, policy => policy.RequireClaim(Permissions.ClaimType, Permissions.ViewTopics));
            });

            services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>();

            services.AddScoped<IAuthorizationHandler, ManageStudentsHandler>();
            services.AddScoped<IAuthorizationHandler, PageOwnerHandler>();
        }
    }
}
