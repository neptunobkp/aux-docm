using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Pulse.Documentos.Api.Services.Email;
using Pulse.Documentos.Domain.Data;
using Pulse.Documentos.Domain.Model;
using Pulse.Documentos.Domain.Model.Dto;

namespace Pulse.Documentos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {

        private readonly DocumentosDbContext _db;
        private readonly IEmailService _emailService;

        public EnvioController(DocumentosDbContext db, IEmailService emailService)
        {
            _db = db;
            _emailService = emailService;
        }

        [HttpGet("Enviar/{id}")]
        public async Task<IActionResult> Enviar(int id)
        {
            var emailInstanceData = await _db.EmailInstances
                .AsNoTracking()
                .Include(t => t.EmailArchivos)
                .ThenInclude(p => p.Archivo)
                .FirstAsync(w => w.Id == id);

            _emailService
                .To(emailInstanceData.Para, emailInstanceData.Para)
                .WithCopys(emailInstanceData.ConCopia?.Split(','))
                .WithBlindCopys(emailInstanceData.ConCopiaOculta?.Split(','))
                .WithDocuments(emailInstanceData.EmailArchivos.ToList())
                .Send(emailInstanceData.Asunto, emailInstanceData.Body);

            return Ok(true);
        }

        [Consumes("application/json", "application/json-patch+json", "multipart/form-data")]
        [HttpPost("Enviar/{id}")]
        public async Task<IActionResult> EnviarAdjuntable(int id)
        {
            var emailInstanceData = await _db.EmailInstances
                .AsNoTracking()
                .Include(t => t.EmailArchivos)
                .ThenInclude(p => p.Archivo)
                .FirstAsync(w => w.Id == id);

            foreach (var cadaAdjunto in Request.Form.Files)
            {
                var ms = new MemoryStream();
                cadaAdjunto.CopyTo(ms);
                emailInstanceData.EmailArchivos.Add(new EmailArchivo
                {
                    Archivo = new Archivo
                    {
                        NombreArchivo = cadaAdjunto.FileName,
                        ArchivoBytes = ms.ToArray()
                    }
                });
            }

            _emailService
                .To(emailInstanceData.Para, emailInstanceData.Para)
                .WithCopys(emailInstanceData.ConCopia?.Split(','))
                .WithBlindCopys(emailInstanceData.ConCopiaOculta?.Split(','))
                .WithDocuments(emailInstanceData.EmailArchivos.ToList())
                .Send(emailInstanceData.Asunto, emailInstanceData.Body);

            return Ok(true);
        }

        [HttpGet("Limpiar/{id}")]
        public async Task<IActionResult> Limpiar(int id)
        {
            var emailInstanceData = await _db.EmailInstances
                .Include(t => t.EmailArchivos)
                .ThenInclude(p => p.Archivo)
                .FirstAsync(w => w.Id == id);

            _db.EmailInstances.Remove(emailInstanceData);
            await _db.SaveChangesAsync();
            return Ok(true);
        }

        [HttpPost("Guardar")]
        public async Task<IActionResult> Post([FromBody] EnvioRequest obj)
        {

            var emailInstance = await _db.EmailInstances.FindAsync(obj.Id);
            emailInstance.Asunto = obj.Asunto;
            emailInstance.Para = obj.Para;
            emailInstance.ConCopia = obj.ConCopia;
            emailInstance.Body = CompleteHtml(obj);

            await _db.SaveChangesAsync();

            return Ok(true);
        }

        private static string CompleteHtml(EnvioRequest obj)
        {
            var result = "<!doctype html><html><head>" + WebUtility.HtmlDecode(obj.Body).Replace("</style>", "</style></head>") + "</body></html>";
            return result;
        }
    }
}