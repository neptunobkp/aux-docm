using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pulse.Documentos.Domain.Data;

namespace Pulse.Documentos.Api.StartupExtensions
{
    public static class EntityFrameworkExtensions
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<DocumentosDbContext>(options =>
            {
                options.ConfigureForCurrentDb(configuration["SQL_CONNECTION"]);
            });
        }
    }
}
