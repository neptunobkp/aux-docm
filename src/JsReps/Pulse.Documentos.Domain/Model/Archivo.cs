namespace Pulse.Documentos.Domain.Model
{
    public class Archivo
    {
        public int Id{ get; set; }
        public byte[] ArchivoBytes { get; set; }
        public string NombreArchivo { get; set; }
        public string Extension { get; set; }
        public int? InstanciaId { get; set; }
    }
}
