using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pulse.Documentos.Domain.Data;
using Pulse.Documentos.Domain.Model;

namespace Pulse.Documentos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly DocumentosDbContext _db;
        public GrupoController(DocumentosDbContext db) => _db = db;

        [HttpGet("{grupoId}/EmailTemplates")]
        public async Task<IEnumerable<EmailTemplate>> EmailTemplates(int grupoId)
        {
            return await _db.EmailTemplates.AsNoTracking().Where(t => t.GrupoId == grupoId).ToListAsync();
        }
    }
}