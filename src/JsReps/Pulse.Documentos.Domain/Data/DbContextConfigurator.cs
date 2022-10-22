using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Pulse.Documentos.Domain.Data
{
    public static class DbContextConfigurator
    {
        public static DbContextOptionsBuilder<DocumentosDbContext> ConfigureForCurrentDb(this DbContextOptionsBuilder builder, string connectionString)
        {
            return (DbContextOptionsBuilder<DocumentosDbContext>)builder
                .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning))
                .UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });
        }
    }
}
