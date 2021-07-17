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

            services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>();
        }
    }
}
