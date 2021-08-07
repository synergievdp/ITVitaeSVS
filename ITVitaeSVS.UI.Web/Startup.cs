using ITVitaeSVS.Core.Application;
using ITVitaeSVS.Infrastructure;
using ITVitaeSVS.Infrastructure.Data;
using ITVitaeSVS.Infrastructure.Identity;
using ITVitaeSVS.UI.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITVitaeSVS.UI.Web {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddApplicationServices();
            services.AddDataServices(Configuration);
            services.AddInfrastructureServices();
            services.AddIdentityServices(Configuration);

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddSingleton<CommonLocalizationService>();

            services.AddMvc().AddViewLocalization();
            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRequestLocalization(options =>
            {
                string[] supportedCultures = { "en", "nl" };

                options.SetDefaultCulture("nl");
                options.AddSupportedCultures(supportedCultures);
                options.AddSupportedUICultures(supportedCultures);

                options.ApplyCurrentCultureToResponseHeaders = true;
            });

            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
            });
        }
    }
}
