using System;
using System.Collections.Generic;
using System.Text;

namespace Pulse.Documentos.Domain.Model
{
    public class EmailTemplate
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }

        public string Para { get; set; }
        public string ConCopia { get; set; }
        public string ConCopiaOculta { get; set; }

        public ICollection<EmailTemplateData> Templates { get; set; }

        public ICollection<EmailPdfTemplate> PdfTemplates { get; set; }
    }
}