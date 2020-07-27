using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.User
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);

        public DbSet<Core.Entities.User> Users { get; set; }
        public DbSet<UserFriends> UserFriends { get; set; }
    }
}
