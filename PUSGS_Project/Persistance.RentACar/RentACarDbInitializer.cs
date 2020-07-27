namespace Persistance.RentACar
{
    public class RentACarDbInitializer
    {
        public static void Initialize(RentACarDbContext context)
        {
            var initializer = new RentACarDbInitializer();
            initializer.SeedEverything(context);
        }

        protected void SeedEverything(RentACarDbContext context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}
