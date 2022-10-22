using jsreport.Local;

namespace Pulse.Documentos.Api.Services
{
    public interface IJsReportService
    {
        ILocalUtilityReportingService Instance();
    }
}