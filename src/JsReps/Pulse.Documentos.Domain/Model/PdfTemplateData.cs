using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Pulse.Documentos.Domain.Model.Masters;
using Pulse.Documentos.Domain.Model.Versions;

namespace Pulse.Documentos.Domain.Model
{
    public class PdfTemplateData
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public TiposIdioma Idioma { get; set; }
        public PdfTemplate PdfTemplate { get; set; }
        public int PdfTemplateId { get; set; }

        public int PdfTemplateDataVersionId { get; set; }
        public PdfTemplateDataVersion PdfTemplateDataVersion { get; set; }

        public int MasterTemplateDataId { get; set; }
        public MasterTemplateData MasterTemplateData { get; set; }
    }
}
