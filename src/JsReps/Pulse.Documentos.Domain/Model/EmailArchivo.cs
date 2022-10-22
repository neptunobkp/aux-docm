using System;
using System.Collections.Generic;
using System.Text;
using Pulse.Documentos.Domain.Model.Instances;

namespace Pulse.Documentos.Domain.Model
{
    public class EmailArchivo
    {
        public int EmailInstanceId { get; set; }
        public int ArchivoId { get; set; }
        public Archivo Archivo { get; set; }
    }
}
