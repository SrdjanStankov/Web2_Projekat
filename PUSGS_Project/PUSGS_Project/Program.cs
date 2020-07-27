using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistance;
using Persistance.Avio;
using Persistance.RentACar;
using Persistance.User;
using System;

namespace PUSGS_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var concreteUserContext = scope.ServiceProvider.GetService<UserDbContext>();
                    UserDbInitializer.Initialize(concreteUserContext);
                    var concreteAvioContext = scope.ServiceProvider.GetService<AvioDbContext>();
                    AvioDbInitializer.Initialize(concreteAvioContext);
                    var concreteRentACarContext = scope.ServiceProvider.GetService<RentACarDbContext>();
                    RentACarDbInitializer.Initialize(concreteRentACarContext);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or initializing the database.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}