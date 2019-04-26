using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectModel.ConsoleApp
{
    public static class Startup
    {
        public static IConfiguration Start()
        {
            // Inicializa o mapper
            Mapper.Initialize(config =>
            {
                config.AddProfile<ConsoleMapperProfile>();
            });

            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
