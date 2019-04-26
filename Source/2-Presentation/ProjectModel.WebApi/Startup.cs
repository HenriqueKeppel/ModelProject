using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using ProjectModel.Domain.Services;
using ProjectModel.Domain.Adapters;
using ProjectModel.Application;
using ProjectModel.GoogleBooksApiAdapter;
using AutoMapper;
using ProjectModel.MapperProfiles;


namespace ProjectModel.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Mapper.Initialize(config =>
            {
                config.AddProfile<WebApiMapperProfile>();
            });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Register the Swagger generator, defining 1 or more swagger documentos
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ProjectModel.WebApi", Version = "v1" });
            });

            // TODO: injetar outras classes            
            services.AddDbReadOnlyAdapter(Configuration.SafeGet<GoogleBooksReadOnlyAdapterConfiguration>());
            services.AddApplication(Configuration.SafeGet<ApplicationConfiguration>());

            services.AddScoped<IGoogleBooksReadOnlyAdapter, GoogleBooksReadOnlyAdapter>();
            services.AddScoped<ILivrosService, LivrosService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectModel.WebApi-v1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
