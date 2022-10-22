using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jsreport.Binary;
using jsreport.Local;

namespace Pulse.Documentos.Api.Services
{
    public class JsReportService : IJsReportService
    {
        public ILocalUtilityReportingService Instance()
        {
            return new LocalReporting()
                .UseBinary(JsReportBinary.GetBinary())
                .AsUtility()
                .Create();
        }
    }
}
