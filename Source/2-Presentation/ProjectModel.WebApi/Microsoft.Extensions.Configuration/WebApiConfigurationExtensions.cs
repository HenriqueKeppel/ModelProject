using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.Configuration
{
    public static class WebApiConfigurationExtensions
    { 
        public static T SafeGet<T>(this IConfiguration configuration)
        {
            var typeName = typeof(T).Name;            

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development"))
            {
                if (configuration.GetChildren().Any(x => x.Key == typeName))
                {
                    configuration = configuration.GetSection(typeName);
                }

                T model = configuration.Get<T>();

                if (model == null)
                    throw new Exception("falhou");

                return model;
            }
            
            T modelo = configuration.Get<T>();

            foreach (var prop in modelo.GetType().GetProperties())
            {
                prop.SetValue(modelo, Environment.GetEnvironmentVariable(prop.Name), null);
            }

            return modelo;
        }
    }
}
