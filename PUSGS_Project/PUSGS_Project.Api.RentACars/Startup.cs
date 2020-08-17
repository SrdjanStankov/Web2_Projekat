using System;
using System.Text;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
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
            services.AddDbContext<UserDbContext>(optionsAction: (options) => options.UseSqlServer(Configuration.GetConnectionString("DefaultUserConnection"), b =>
            {
                b.MigrationsAssembly("Persistance.User");
                b.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
            }));
            services.AddDbContext<RentACarDbContext>(optionsAction: (options) => options.UseSqlServer(Configuration.GetConnectionString("DefaultRentACarConnection"), b =>
            {
                b.MigrationsAssembly("Persistance.RentACar");
                b.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
            }));

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IRentACarRepository, RentACarRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<ICarReservationRepository, CarReservationRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();

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
