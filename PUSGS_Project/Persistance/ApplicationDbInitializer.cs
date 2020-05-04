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
        }
    }
}