using System;
using System.Collections.Generic;
using System.Text;

namespace Pulse.Documentos.Domain.Model
{
    public class Version
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
    }
}
