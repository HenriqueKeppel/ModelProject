using ProjectModel.GoogleBooksApiAdapter;
using ProjectModel.Domain.Adapters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DbAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddDbReadOnlyAdapter(this IServiceCollection services, GoogleBooksReadOnlyAdapterConfiguration AdapterConfigurarion)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (AdapterConfigurarion == null)
                throw new ArgumentNullException(nameof(AdapterConfigurarion));

            // Registra instancia do objeto de configuracoes desta camada.
            services.AddSingleton(AdapterConfigurarion);

            services.AddScoped<IGoogleBooksReadOnlyAdapter, GoogleBooksReadOnlyAdapter>();

            return services;
        }
    }
}
