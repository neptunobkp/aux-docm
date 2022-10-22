using System.Collections.Generic;
using Pulse.Documentos.Domain.Model;

namespace Pulse.Documentos.Api.Services.Email
{
    public interface IEmailService
    {
        void Send(string subject, string message);
        EmailService To(string name, string email);
        EmailService WithCopys(string[] emails);
        EmailService WithBlindCopys(string[] emails);
        EmailService WithDocument(string filename, byte[] buffer);

        EmailService WithDocuments(List<EmailArchivo> archivos);
    }
}
