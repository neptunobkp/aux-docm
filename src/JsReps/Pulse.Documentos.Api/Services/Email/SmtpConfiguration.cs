namespace Pulse.Documentos.Api.Services.Email
{
    public class SmtpConfiguration 
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string DefaultDestination { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
    }
}
