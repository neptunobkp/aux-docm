using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using jsreport.AspNetCore;
using jsreport.Types;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Pulse.Documentos.Api.Services.Templating
{
    public class TemplateService : ITemplateService
    {
        public IJsReportMVCService JsReportMvcService { get; }

        public TemplateService(IJsReportMVCService jsReportMvcService)
        {
            JsReportMvcService = jsReportMvcService;
        }

        public async Task<string> TemplateHtml(string payload, string template)
        {
            var report = await JsReportMvcService.RenderAsync(new RenderRequest()
            {
                Template = new Template
                {
                    Content = template,
                    Engine = Engine.Handlebars,
                    Recipe = Recipe.Html
                },
                Data = JsonConvert.DeserializeObject(payload)
            });

            return new StreamReader(report.Content).ReadToEnd();
        }


        public async Task<byte[]> TemplatePdf(string payload, string template)
        {
            var report = await JsReportMvcService.RenderAsync(new RenderRequest()
            {
                Template = new Template
                {
                    Content = template,
                    Engine = Engine.Handlebars,
                    Recipe = Recipe.ChromePdf
                },
                Data = JsonConvert.DeserializeObject(payload)
            });

            var memoryStream = new MemoryStream();
            await report.Content.CopyToAsync(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream.ToArray();
        }
    }
}
