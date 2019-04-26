using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Microsoft.Extensions.Configuration
{
    public static class ConsoleConfigurationExtensions
    {
        public static T SafeGet<T>(this IConfiguration configuration)
        {
            var typeName = typeof(T).Name;

            if (configuration.GetChildren().Any(x => x.Key == typeName))
            {
                configuration = configuration.GetSection(typeName);
            }

            T model = configuration.Get<T>();

            if (model == null)
                throw new Exception("falhou");
            return model;
        }
    }
}
