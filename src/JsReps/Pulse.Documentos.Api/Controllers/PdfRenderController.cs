using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using jsreport.AspNetCore;
using jsreport.Binary;
using jsreport.Local;
using jsreport.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pulse.Documentos.Api.Services;
using System.Resources;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pulse.Documentos.Domain.Data;
using Pulse.Documentos.Domain.Model;

namespace Pulse.Documentos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfRenderController : ControllerBase
    {
        private readonly DocumentosDbContext _db;
        public IJsReportMVCService JsReportMvcService { get; }

        public PdfRenderController(IJsReportMVCService jsReportMvcService, DocumentosDbContext db)
        {
            JsReportMvcService = jsReportMvcService;
            _db = db;
        }

        [HttpPost("{templateId}/{idioma}")]
        public async Task<IActionResult> Post(int templateId, int idioma)
        {
            var pdfTemplate = _db.PdfTemplateData.Include(t => t.MasterTemplateData).First(t => t.PdfTemplateId == templateId && t.Idioma == (TiposIdioma)idioma);

            string payload = new StreamReader(Request.Body).ReadToEnd();
            var report = await JsReportMvcService.RenderAsync(new RenderRequest()
            {
                Template = new Template
                {
                    Content = pdfTemplate.MasterTemplateData.Body.Replace("#Contenido#", pdfTemplate.Body),
                    Engine = Engine.Handlebars,
                    Recipe = Recipe.ChromePdf
                },
                Data = JsonConvert.DeserializeObject(payload)
            });
        
            var memoryStream = new MemoryStream();
            await report.Content.CopyToAsync(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return File(memoryStream, "application/pdf");
        }
    }
}