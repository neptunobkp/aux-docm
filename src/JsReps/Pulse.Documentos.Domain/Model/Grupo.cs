using System;
using System.Collections.Generic;
using System.Text;

namespace Pulse.Documentos.Domain.Model
{
    public class Grupo
    {
        public int Id { get; set; }
        public int AplicacionId { get; set; }
        public Aplicacion Aplicacion { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}
