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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PUSGS_Project.ApiGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true")
            {
                services.Configure<Settings>(configOptions =>
                    {
                        configOptions.UserApiUrl = $"https://{Configuration["API_USER_SERVICE_SERVICE_HOST"]}:{Configuration["API_USER_SERVICE_SERVICE_PORT_HTTPS"]}";
                        configOptions.RentACarApiUrl = $"https://{Configuration["API_RENTACAR_SERVICE_SERVICE_HOST"]}:{Configuration["API_RENTACAR_SERVICE_SERVICE_PORT_HTTPS"]}";
                        configOptions.AviationAipUrl = $"https://{Configuration["API_AVIATION_SERVICE_SERVICE_HOST"]}:{Configuration["API_AVIATION_SERVICE_SERVICE_PORT_HTTPS"]}";
                    }); 
            }
            else
            {
                services.Configure<Settings>(Configuration.GetSection("Settings"));
            }

            services.AddCors();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(config =>
            {
                config.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });

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
