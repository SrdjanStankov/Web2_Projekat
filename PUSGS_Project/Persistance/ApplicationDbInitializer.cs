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

            // TODO: Seed database

            // create System admin if not exist
            var sysAdmin = new SystemAdministrator()
            {
                Email = @"admin@gmail.com",
                City = "Admin city",
                IsRentACarAdmin = false,
                IsSystemAdmin = true,
                IsVerified = true,
                LastName = "Admin",
                Name = "Admin",
                Password = "123",
                Phone = "123admin"
            };
            _ = context.User.FirstOrDefault(u => u.Email == sysAdmin.Email) ?? context.User.Add(sysAdmin).Entity;
            context.SaveChanges();
        }
    }
}