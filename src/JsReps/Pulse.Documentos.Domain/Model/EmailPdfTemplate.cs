using System;
using System.Collections.Generic;
using System.Text;

namespace Pulse.Documentos.Domain.Model
{
   public  class EmailPdfTemplate
    {
        public int EmailTemplateId { get; set; }
        public EmailTemplate EmailTemplate { get; set; }
        public int PdfTemplateId { get; set; }
        public PdfTemplate PdfTemplate { get; set; }
    }
}
