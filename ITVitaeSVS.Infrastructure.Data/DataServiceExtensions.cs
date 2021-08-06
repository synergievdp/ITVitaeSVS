using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITVitaeSVS.Infrastructure.Data
{
    public static class DataServiceExtensions
    {
        public static void AddDataServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataDbContext>(
                options =>
                    options.UseSqlServer(config.GetConnectionString("DataDbContext"),
                builder =>
                    builder.MigrationsAssembly(typeof(DataDbContext).Assembly.FullName))
            );
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
        }
    }
}
