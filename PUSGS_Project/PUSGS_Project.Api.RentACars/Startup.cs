using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistance.RentACar;
using Persistance.RentACar.Repositories;
using Persistance.User;
using Persistance.User.Repositories;

namespace PUSGS_Project.Api.RentACars
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
            services.AddDbContext<RentACarDbContext>(optionsAction: (options) => options.UseSqlServer(Configuration.GetConnectionString("DefaultRentACarConnection"), b => b.MigrationsAssembly("Persistance.RentACar")));

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IRentACarRepository, RentACarRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<ICarReservationRepository, CarReservationRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();

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
