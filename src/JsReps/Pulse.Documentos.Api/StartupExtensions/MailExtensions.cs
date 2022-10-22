using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pulse.Documentos.Api.Services.Email;

namespace Pulse.Documentos.Api.StartupExtensions
{
    public static class MailExtensions
    {
        public static IServiceCollection AddEmailService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmailService, EmailService>();
            services.Configure<SmtpConfiguration>(configuration.GetSection("SmtpConfiguration"));
            return services;
        }
    }
}
