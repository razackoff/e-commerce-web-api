using Microsoft.EntityFrameworkCore;
using Market.Application.Interfaces;
using Market.Domain;
using Market.Persistence.EntityTypeConfigurations;

namespace Market.Persistence
{
    public class ProductDbContext : DbContext, IProductDbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
