using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jsreport.AspNetCore;
using jsreport.Binary;
using jsreport.Local;
using jsreport.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pulse.Documentos.Api.Services;
using Pulse.Documentos.Api.Services.Templating;
using Pulse.Documentos.Domain.Data;
using Pulse.Documentos.Api.StartupExtensions;

namespace Pulse.Documentos.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IJsReportService, JsReportService>();
            services.AddTransient<ITemplateService, TemplateService>();
            services.AddEntityFramework(Configuration);
            services.AddEmailService(Configuration);
            services.AddMvcWithRazorOptions();
            services.AddJsReport(new LocalReporting()
                .UseBinary(JsReportBinary.GetBinary())
                .Configure(c => { c.Chrome = new ChromeConfiguration { Timeout = 1000000 }; return c; })
                .AsUtility()
                .Create());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            RunMigration(serviceProvider);

            app.UseStaticFiles();
            app.UseMvc();
        }

        private static void RunMigration(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<DocumentosDbContext>();
            context.RunMigration();
        }
    }
}
