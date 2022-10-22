using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using Pulse.Documentos.Domain.Model;

namespace Pulse.Documentos.Api.Services.Email
{
    public class EmailService : IEmailService
    {
        private IHostingEnvironment _hostingEnv;
        public EmailService(IOptions<SmtpConfiguration> optionsAccessor, IHostingEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;
            Options = optionsAccessor.Value;
        }

        private string Email { get; set; }
        private string Name { get; set; }
        private List<string> CCs { get; set; } = new List<string>();
        private List<string> BlindCopys { get; set; } = new List<string>();
        private Dictionary<string, byte[]> Attachments { get; set; } = new Dictionary<string, byte[]>();

        private SmtpConfiguration Options { get; }

        public EmailService To(string name, string email)
        {
            Email = email;
            Name = name;
            return this;
        }

        public EmailService WithCopys(string[] emails)
        {
            if (emails == null || emails.Length == 0) return this;

            CCs = emails.ToList();
            return this;
        }

        public EmailService WithBlindCopys(string[] emails)
        {
            if (emails == null || emails.Length == 0) return this;

            BlindCopys = emails.ToList();
            return this;
        }

        public EmailService WithDocument(string filename, byte[] buffer)
        {
            Attachments.Add(filename, buffer);
            return this;
        }

        public EmailService WithDocuments(List<EmailArchivo> archivos)
        {
            if (archivos == null || archivos.Count == 0) return this;
            foreach (var each in archivos)
            {
                Attachments.Add(each.Archivo.NombreArchivo, each.Archivo.ArchivoBytes);
            }
            return this;
        }

        public void Send(string subject, string message)
        {
            var mimeMessage = new MimeMessage();

            mimeMessage.From.Add(new MailboxAddress(Options.OwnerName, Options.OwnerEmail));

            if (_hostingEnv.IsProduction())
            {
                mimeMessage.To.Add(new MailboxAddress(Name, Email));
                CCs.ForEach(t => mimeMessage.Cc.Add(new MailboxAddress(t.Trim())));
                BlindCopys.ForEach(t => mimeMessage.Cc.Add(new MailboxAddress(t.Trim())));
            }
            else
            {
                mimeMessage.To.Add(new MailboxAddress(Options.DefaultDestination));
                if (string.CompareOrdinal(Options.DefaultDestination, Email) == 0)
                    if (Email.ToLower().Contains("auxilia") || Email.ToLower().Contains("pulse"))
                        mimeMessage.To.Add(new MailboxAddress(Name, Email));
            }

            mimeMessage.Subject = subject;

            var builder = new BodyBuilder { HtmlBody = message };
            foreach (var eachAttach in Attachments)
                builder.Attachments.Add(eachAttach.Key, eachAttach.Value);
            mimeMessage.Body = builder.ToMessageBody();

            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect(Options.Server, Options.Port, false);
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                emailClient.Authenticate(Options.UserName, Options.Pwd);
                emailClient.Send(mimeMessage);
                emailClient.Disconnect(true);
            }
        }
    }
}
