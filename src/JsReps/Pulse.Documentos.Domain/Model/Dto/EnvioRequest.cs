using System;
using System.Collections.Generic;
using System.Text;

namespace Pulse.Documentos.Domain.Model.Dto
{
   public  class EnvioRequest
    {
        public int Id { get; set; }
        public string Asunto { get; set; }
        public string Para { get; set; }
        public string ConCopia { get; set; }
        public string Body { get; set; }
    }
}
