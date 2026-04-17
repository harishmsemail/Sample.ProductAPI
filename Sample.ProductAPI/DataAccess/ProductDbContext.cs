using Microsoft.EntityFrameworkCore;
using Sample.ProductAPI.Models;

namespace Sample.ProductAPI.DataAccess
{
    // Database context for interacting with product-related data.
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products
        {
            get; set;

        }
        public DbSet<ProductAttribute> ProductAttributes
        {
            get; set;
        }
    }
}