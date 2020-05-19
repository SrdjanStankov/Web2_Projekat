using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Core.Interfaces.Repositories;
using Persistance.Repositories;

namespace PUSGS_Project
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
            services.AddCors();

            // Add DbContext using SQL Server Provider
            string connectionString = this.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(optionsAction: (options) =>
          options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Persistance")));

            // TODO: Add services here
            services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
            services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production
                // scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(options =>
            {
                options
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core, see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    /*
                     * Starts back end seperately from the front end (angular)
                     * To start both:
                     * 1. In Console (ex. cmd/powershell) navigate to `ClientApp` and run `npm start`
                     * 2. Start backend
                     */
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");

                    // Starts Angular server automatically when you start backend
                    // spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}