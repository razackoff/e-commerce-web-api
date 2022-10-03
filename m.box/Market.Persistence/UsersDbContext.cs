using Microsoft.EntityFrameworkCore;
using Market.Application.Interfaces;
using Market.Domain;
using Market.Persistence.EntityTypeConfigurations;

namespace Market.Persistence
{
    public class UsersDbContext : DbContext, IUserDbContext
    {
        public DbSet<User> Users { get; set; }
        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
