using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application {
    public static class ApplicationServiceExtensions {
        public static void AddApplicationServices(this IServiceCollection services) {
            services.AddScoped<ICertificateService, CertificateService>();
            services.AddScoped<ILevelService, LevelService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IWorkMethodService, WorkMethodService>();
            services.AddScoped<IRequisiteService, RequisiteService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISubjectService, SubjectService>();
        }
    }
}
