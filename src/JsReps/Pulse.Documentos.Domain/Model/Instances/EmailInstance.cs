using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Pulse.Documentos.Domain.Model.Versions;

namespace Pulse.Documentos.Domain.Model.Instances
{
    public class EmailInstance
    {
        public EmailInstance()
        {
            EmailArchivos = new List<EmailArchivo>();
        }

        public int Id { get; set; }
        public int? EmailTemplateId { get; set; }
        public EmailTemplate EmailTemplate { get; set; }

        public int? EmailTemplateDataVersionId { get; set; }
        public EmailTemplateDataVersion EmailTemplateDataVersion { get; set; }

        public string Para { get; set; }
        public string ConCopia { get; set; }
        public string ConCopiaOculta { get; set; }
        public string Asunto { get; set; }

        public string Payload { get; set; }
        public string Requester { get; set; }
        public string Body { get; set; }

        public string ExternalKey1 { get; set; }
        public string ExternalKey2 { get; set; }
        public int? ExternalKey3 { get; set; }
        public DateTime Fecha { get; set; }


        public ICollection<EmailArchivo> EmailArchivos { get; set; }

        public TiposIdioma Idioma { get; set; }

    }
}
