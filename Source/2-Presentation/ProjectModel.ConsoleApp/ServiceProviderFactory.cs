using Microsoft.Extensions.DependencyInjection;
using ProjectModel.Application;
using ProjectModel.GoogleBooksApiAdapter;
using ProjectModel.Domain.Adapters;
using ProjectModel.Domain.Services;
using System;
using bs2.comp.SysLog.Interfaces;
using bs2.comp.SysLog;

namespace ProjectModel.ConsoleApp
{
    public class ServiceProviderFactory
    {
        private readonly IServiceCollection services;

        public ServiceProviderFactory(Action<IServiceCollection> serviceLambda)
        {
            services = new ServiceCollection();
            serviceLambda?.Invoke(services);
        }

        public IServiceProvider CreateServiceProvider()
        {
            services.AddScoped<IGoogleBooksReadOnlyAdapter, GoogleBooksReadOnlyAdapter>();
            services.AddScoped<ILivrosService, LivrosService>();

            return services.BuildServiceProvider();
        }
    }
}
