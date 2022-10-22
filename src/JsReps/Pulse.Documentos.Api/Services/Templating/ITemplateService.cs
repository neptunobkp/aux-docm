using System.Threading.Tasks;

namespace Pulse.Documentos.Api.Services.Templating
{
    public interface ITemplateService
    {
        Task<string> TemplateHtml(string payload, string template);
        Task<byte[]> TemplatePdf(string payload, string template);
    }
}