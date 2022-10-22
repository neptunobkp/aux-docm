using System;
using System.Collections.Generic;
using System.Text;

namespace Pulse.Documentos.Domain.Model
{
    public class Aplicacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Grupo> Grupos { get; set; }
    }
}
