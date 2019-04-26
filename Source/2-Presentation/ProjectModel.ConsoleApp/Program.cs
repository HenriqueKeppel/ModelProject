using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectModel.Application;
using ProjectModel.ConsoleApp.Dto;
using ProjectModel.GoogleBooksApiAdapter;
using ProjectModel.Domain.Services;
using Newtonsoft.Json;
using AutoMapper;
using System.Threading.Tasks;

namespace ProjectModel.ConsoleApp
{
    class Program
    {
        private static IConfiguration _configuration { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Service");

            _configuration = Startup.Start();

            ServiceProviderFactory serviceProviderFactory = new ServiceProviderFactory(services =>
            {
                services.AddDbReadOnlyAdapter(_configuration.SafeGet<GoogleBooksReadOnlyAdapterConfiguration>());
                services.AddApplication(_configuration.SafeGet<ApplicationConfiguration>());
            });

            var serviceProvider = serviceProviderFactory.CreateServiceProvider();
            ConsoleService service = new ConsoleService(serviceProvider.GetService<ILivrosService>());

            // Obter consulta default
            ConsoleConfiguration consoleOptions = _configuration.SafeGet<ConsoleConfiguration>();

            IEnumerable<LivroDto> retorno = service.obterLivrosPorTitulo(consoleOptions.ConsultaDefault).Result;

            foreach (LivroDto dto in retorno)
            {
                Console.WriteLine(string.Format("Livro: {0}\n", JsonConvert.SerializeObject(dto)));
            }
            Console.ReadKey();
        }
    }
}
