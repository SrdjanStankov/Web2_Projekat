namespace Persistance.Avio
{
    public class AvioDbInitializer
    {
        public static void Initialize(AvioDbContext context)
        {
            var initializer = new AvioDbInitializer();
            initializer.SeedEverything(context);
        }

        protected void SeedEverything(AvioDbContext context) => context.Database.EnsureCreated();
    }
}
