using bs2.comp.SysLog;
using bs2.comp.SysLog.Interfaces;
using ProjectModel.Application;
using ProjectModel.Domain.Services;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, ApplicationConfiguration applicationConfiguration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (applicationConfiguration == null)
            {
                throw new ArgumentNullException(nameof(applicationConfiguration));
            }

            // Registra a instancia do objeto de configuracoes desta camanda.
            services.AddSingleton(applicationConfiguration);

            // Registra a instancia do objeto de log
            services.AddTransient<ISysLog, Logger>();

            // Registra o servico descrito pela interface ILivrosService
            services.AddScoped<ILivrosService, LivrosService>();

            return services;
        }
    }
}
