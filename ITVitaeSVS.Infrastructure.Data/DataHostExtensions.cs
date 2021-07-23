using ITVitaeSVS.Core.Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Infrastructure.Data
{
    public static class DataHostExtensions
    { 
        public static IHost InitializeData(this IHost host)
        {
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DataDbContext>();
                    var csvReader = services.GetRequiredService<ICSVReader>();

                    context.Database.Migrate();
                    SeedData(csvReader);
                } catch (Exception ex)
                {
                    throw;
                }
            }
            return host;

        }

        public static void SeedData(ICSVReader csvReader)
        {
            using (var dropdown = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "DropdownDataInfra.csv")).BaseStream)
            {
                csvReader.ReadDropDownCSV(dropdown, '$');
            }
            using (var topics = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "TopicDataInfra.csv")).BaseStream)
            {
                csvReader.ReadTopicCSV(topics, '$');
            }
        }
    }
}
