using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistance.Avio;
using Persistance.Avio.Repositories;
using Persistance.User;
using Persistance.User.Repositories;

namespace PUSGS_Project.Api.Aviations
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
            services.AddDbContext<UserDbContext>(optionsAction: (options) => options.UseSqlServer(Configuration.GetConnectionString("DefaultUserConnection"), b => b.MigrationsAssembly("Persistance.User")));
            services.AddDbContext<AvioDbContext>(optionsAction: (options) => options.UseSqlServer(Configuration.GetConnectionString("DefaultAvioConnection"), b => b.MigrationsAssembly("Persistance.Avio")));

            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAviationRepository, AviationRepository>();
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IFlightSeatRepository, FlightSeatRepository>();
            services.AddScoped<IFlightTicketRepository, FlightTicketRepository>();

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAviationService, AviationService>();
            services.AddScoped<IFlightService, FlightService>();

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

            app.UseCors(options =>
            {
                options
                .WithOrigins("http://localhost:4200")
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
