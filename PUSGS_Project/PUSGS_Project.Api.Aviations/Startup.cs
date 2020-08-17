using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
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
            services.AddDbContext<UserDbContext>(optionsAction: (options) => options.UseSqlServer(Configuration.GetConnectionString("DefaultUserConnection"), b => 
            { 
                b.MigrationsAssembly("Persistance.User");
                b.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
            }));
            services.AddDbContext<AvioDbContext>(optionsAction: (options) => options.UseSqlServer(Configuration.GetConnectionString("DefaultAvioConnection"), b =>
            {
                b.MigrationsAssembly("Persistance.Avio");
                b.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
            }));

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

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x =>
            {
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

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
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
