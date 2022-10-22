using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using jsreport.AspNetCore;
using jsreport.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pulse.Documentos.Api.Services.Templating;
using Pulse.Documentos.Domain.Data;
using Pulse.Documentos.Domain.Model;
using Pulse.Documentos.Domain.Model.Dto;
using Pulse.Documentos.Domain.Model.Instances;

namespace Pulse.Documentos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private readonly DocumentosDbContext _db;
        private readonly ITemplateService _templateService;
        private readonly IUrlHelper _urlHelper;

        public EmailController(DocumentosDbContext db, IUrlHelper urlHelper, ITemplateService templateService)
        {
            _db = db;
            _urlHelper = urlHelper;
            _templateService = templateService;
        }

        [HttpGet("{id}")]
        public async Task<EmailInstance> Get(int id)
        {
            return await _db.EmailInstances.Include(t => t.EmailArchivos).FirstAsync(t => t.Id == id);
        }

        [HttpPost("{idioma}/{para}/{templateId}/{asunto}")]
        public async Task<MailingResponse> Post(string idioma, string para, int templateId, string asunto)
        {
            Enum.TryParse(idioma, true, out TiposIdioma tipoIdioma);

            var emailTemplate = _db.EmailTemplateData
                .Include(t => t.EmailTemplate)
                .Include(t => t.MasterTemplateData)
                .Include(t => t.EmailTemplate.PdfTemplates)
                .First(t => t.EmailTemplateId == templateId && t.Idioma == tipoIdioma);

            var payload = new StreamReader(Request.Body).ReadToEnd();
            var template = emailTemplate.MasterTemplateData.Body.Replace("#Contenido#", emailTemplate.Cuerpo);
            var htmlResult = await _templateService.TemplateHtml(payload, template);

            var emailInstance = new EmailInstance
            {
                Body = htmlResult,
                Para = para,
                Asunto = asunto,
                ConCopia = emailTemplate.EmailTemplate.ConCopia,
                ConCopiaOculta = emailTemplate.EmailTemplate.ConCopiaOculta,
                EmailTemplateId = emailTemplate.EmailTemplateId,
                EmailTemplateDataVersionId = emailTemplate.EmailTemplateDataVersionId,
                Fecha = DateTime.Now,
                Payload = payload,
                Idioma = tipoIdioma
            };

            foreach (var each in emailTemplate.EmailTemplate.PdfTemplates)
            {
                var eachPdfTemplate = _db.PdfTemplateData
                    .Include(t => t.PdfTemplate)
                    .Include(t => t.MasterTemplateData).First(t => t.PdfTemplateId == each.PdfTemplateId && t.Idioma == tipoIdioma);
                var eachTemplate = eachPdfTemplate.MasterTemplateData.Body.Replace("#Contenido#", eachPdfTemplate.Body);
                var pdfBuffer = await _templateService.TemplatePdf(payload, eachTemplate);

                var newArchivo = new Archivo
                {
                    ArchivoBytes = pdfBuffer,
                    NombreArchivo = $"{eachPdfTemplate.PdfTemplate.Codigo}.pdf",
                    Extension = "application/pdf"
                };
                await _db.Archivos.AddAsync(newArchivo);
                await _db.SaveChangesAsync();

                emailInstance.EmailArchivos.Add(new EmailArchivo
                {
                    ArchivoId = newArchivo.Id
                });
            }

            _db.EmailInstances.Add(emailInstance);
            _db.SaveChanges();

            var instanceUrl = _urlHelper.Action("Get", "Email", new { id = emailInstance.Id }, protocol: Request.Scheme);

            return new MailingResponse
            {
                UrlEdicion = instanceUrl.Replace("api/", ""),
                UrlInstancia = instanceUrl.Replace("api/Email", "Email/Ver"),
                UrlEnvio = _urlHelper.Action("Enviar", "Envio", new { id = emailInstance.Id }, protocol: Request.Scheme),
                UrlLimpiar = _urlHelper.Action("Limpiar", "Envio", new { id = emailInstance.Id }, protocol: Request.Scheme)
            };
        }
    }
}