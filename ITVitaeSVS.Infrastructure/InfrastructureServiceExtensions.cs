using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Infrastructure {
    public static class InfrastructureServiceExtensions {
        public static void AddInfrastructureServices(this IServiceCollection services) {
            services.AddScoped<ICSVReader, CSVReader>();
        }
    }
}
