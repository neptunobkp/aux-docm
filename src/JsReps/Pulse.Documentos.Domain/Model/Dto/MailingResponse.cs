using System;
using System.Collections.Generic;
using System.Text;

namespace Pulse.Documentos.Domain.Model.Dto
{
    public class MailingResponse
    {
        public string UrlEdicion { get; set; }
        public string UrlInstancia { get; set; }
        public string UrlEnvio { get; set; }
        public string UrlLimpiar { get; set; }
    }
}
