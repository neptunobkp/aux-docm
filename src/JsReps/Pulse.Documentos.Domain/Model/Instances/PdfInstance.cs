using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Pulse.Documentos.Domain.Model.Versions;

namespace Pulse.Documentos.Domain.Model.Instances
{
    public class PdfInstance
    {
        public int Id { get; set; }
        public int? PdfTemplateId { get; set; }
        public PdfTemplate PdfTemplate { get; set; }

        public int? PdfTemplateDataVersionId { get; set; }
        public PdfTemplateDataVersion PdfTemplateDataVersion { get; set; }

        public string Payload { get; set; }
        public string Body { get; set; }
        public string Requester { get; set; }

        public string ExternalKey1 { get; set; }
        public string ExternalKey2 { get; set; }
        public int? ExternalKey3 { get; set; }

        public DateTime Fecha { get; set; }
    }
}
