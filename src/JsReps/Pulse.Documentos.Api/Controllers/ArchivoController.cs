using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pulse.Documentos.Domain.Data;

namespace Pulse.Documentos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoController : ControllerBase
    {
        private readonly DocumentosDbContext _db;
        public ArchivoController(DocumentosDbContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var archivo = await _db.Archivos.FindAsync(id);
            return File(archivo.ArchivoBytes, archivo.Extension, archivo.NombreArchivo);
        }
    }
}