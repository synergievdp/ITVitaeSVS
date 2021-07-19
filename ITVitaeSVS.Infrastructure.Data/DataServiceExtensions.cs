using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Infrastructure.Data {
    public static class DataServiceExtensions {
        public static void AddDataServices(this IServiceCollection services) {
            services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
