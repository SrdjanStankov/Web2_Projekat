using System.Linq;
using Core.Entities;

namespace Persistance
{
    public class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var initializer = new ApplicationDbInitializer();
            initializer.SeedEverything(context);
        }

        protected void SeedEverything(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // create System admin if not exist
            var sysAdmin = new SystemAdministrator()
            {
                Email = @"admin@gmail.com",
                City = "Admin city",
                IsVerified = true,
                LastName = "Admin",
                Name = "Admin",
                Password = "123",
                Phone = "123admin"
            };
            _ = context.User.FirstOrDefault(u => u.Email == sysAdmin.Email) ?? context.User.Add(sysAdmin).Entity;

            var carAdmin = new RentACarAdministrator()
            {
                Email = @"car.admin@gmail.com",
                City = "Car admin city",
                IsVerified = true,
                LastName = "Car Admin",
                Name = "Car Admin",
                Password = "123",
                Phone = "123caradmin"
            };

            if (!context.User.Any(u => u.Email == carAdmin.Email))
            {
                context.User.Add(carAdmin);
            }

            var aviationAdmin = new AviationAdministrator()
            {
                Email = @"aviation.admin@gmail.com",
                City = "Aviation admin city",
                IsVerified = true,
                LastName = "Aviation Admin",
                Name = "Aviation Admin",
                Password = "123",
                Phone = "123aviationadmin"
            };

            if (!context.User.Any(u => u.Email == aviationAdmin.Email))
            {
                context.User.Add(aviationAdmin);
            }

            context.SaveChanges();
        }
    }
}