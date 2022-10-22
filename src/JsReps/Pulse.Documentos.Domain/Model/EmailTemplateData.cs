using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Pulse.Documentos.Domain.Model.Masters;
using Pulse.Documentos.Domain.Model.Versions;

namespace Pulse.Documentos.Domain.Model
{
    public class EmailTemplateData
    {
        public int Id { get; set; }
        public TiposIdioma Idioma { get; set; }
        public string Cuerpo { get; set; }

        public string Asunto { get; set; }
        public EmailTemplate EmailTemplate { get; set; }
        public int EmailTemplateId { get; set; }

        public int EmailTemplateDataVersionId { get; set; }
        public EmailTemplateDataVersion EmailTemplateDataVersion { get; set; }

        public int MasterTemplateDataId { get; set; }
        public MasterTemplateData MasterTemplateData { get; set; }
    }
}
