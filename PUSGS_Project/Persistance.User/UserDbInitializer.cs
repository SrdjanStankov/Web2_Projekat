using System.Linq;
using Core.Entities;

namespace Persistance.User
{
    public class UserDbInitializer
    {
        public static void Initialize(UserDbContext context)
        {
            var initializer = new UserDbInitializer();
            initializer.SeedEverything(context);
        }

        protected void SeedEverything(UserDbContext context)
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
            _ = context.Users.FirstOrDefault(u => u.Email == sysAdmin.Email) ?? context.Users.Add(sysAdmin).Entity;

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

            if (!context.Users.Any(u => u.Email == carAdmin.Email))
            {
                context.Users.Add(carAdmin);
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

            if (!context.Users.Any(u => u.Email == aviationAdmin.Email))
            {
                context.Users.Add(aviationAdmin);
            }

            context.SaveChanges();
        }
    }
}
