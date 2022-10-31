using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FMI.Gateways.Services.Extensions;
using FMI.Gateways.Services.Repositories;
using FMI.Gateways.Services.Repositories.Contracts;
using FMI.Gateways.Services.Services;
using FMI.Gateways.Services.Services.Contracts;
using System;

namespace FMI.Gateways.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureContext(Configuration);

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IGatewayRepository, GatewayRepository>();
            services.AddScoped<IPeripherialDeviceRepository, PeripheralDeviceRepository>();

            services.AddScoped<IGatewayService, GatewayService>();
            services.AddScoped<IPeripherialDeviceService, PeripherialDeviceService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "FMI Gateways API",
                    Description = "FMI Gateways API",
                    Contact = new OpenApiContact
                    {
                        Name = "Tanyo Ivanov",
                        Email = string.Empty,
                        Url = new Uri("https://www.facebook.com/dev.takerman"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

#if DEBUG
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FMI Gateways API V1");
                c.RoutePrefix = string.Empty;
            });
#endif

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}