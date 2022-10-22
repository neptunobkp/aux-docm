using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RtfPipe;

namespace Pulse.Documentos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RtfRenderController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody]string input)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var html = Rtf.ToHtml(input);
            return html;
        }
    }
}