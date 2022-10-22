using System;
using System.Collections.Generic;
using System.Text;

namespace Pulse.Documentos.Domain.Model
{
    public class PdfTemplate
    {
        public int Id { get; set; }
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }
        public string Codigo { get; set; }
        public ICollection<PdfTemplateData> Templates { get; set; }
        public ICollection<EmailPdfTemplate> EmailTemplates { get; set; }
    }
}
