using System;
using System.Collections.Generic;
using System.Text;

namespace Pulse.Documentos.Domain.Model.Versions
{
    public class PdfTemplateDataVersion
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public bool Draft { get; set; }
    }
}
