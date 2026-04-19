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

        /// <summary>
        /// Overrides the default model creation process to apply custom configurations and data seeding.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Product Entity Configuration ---
            modelBuilder.Entity<Product>(entity =>
            {
                // Defines the primary key for the Product entity.
                entity.HasKey(p => p.ProductId);

                // Configures the ProductName property to be required with a maximum length of 100 characters.
                entity.Property(p => p.ProductName)
                    .IsRequired()
                    .HasMaxLength(100);

                // These properties are configured.
                entity.Property(p => p.PricePerItem);
                entity.Property(p => p.AverageCustomerRating);

                // Seeds the database with initial product data for development and testing.
                entity.HasData(
                    new { ProductId = 1, ProductName = "Laptop", PricePerItem = 1499.99m, AverageCustomerRating = 4.8m },
                    new { ProductId = 2, ProductName = "Keyboard", PricePerItem = 150.00m, AverageCustomerRating = 4.6m },
                    new { ProductId = 3, ProductName = "4K Monitor", PricePerItem = 799.50m, AverageCustomerRating = 4.9m },
                    new { ProductId = 4, ProductName = "Headset", PricePerItem = 99.99m, AverageCustomerRating = 4.4m }
                );
            });

            // --- ProductAttribute Entity Configuration ---
            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                // Defines the primary key for the ProductAttribute entity.
                entity.HasKey(pa => pa.ProductAttributeId);

                // Configures the Name property to be required with a maximum length.
                entity.Property(pa => pa.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                // Configures the Value property to be required with a maximum length.
                entity.Property(pa => pa.Value)
                    .IsRequired()
                    .HasMaxLength(100);

                // Defines the many-to-one relationship where one Product can have many Attributes.
                entity.HasOne<Product>()
                    .WithMany(p => p.Attributes)
                    .HasForeignKey("ProductId")
                    // Configures cascade delete: when a Product is deleted, its associated Attributes are also deleted.
                    .OnDelete(DeleteBehavior.Cascade);

                // Seeds the database with initial attribute data linked to the products.
                entity.HasData(
                    new { ProductAttributeId = 1, ProductId = 1, Name = "Color", Value = "Black" },
                    new { ProductAttributeId = 2, ProductId = 1, Name = "RAM", Value = "32GB" },
                    new { ProductAttributeId = 3, ProductId = 1, Name = "Storage", Value = "1TB SSD" },
                    new { ProductAttributeId = 4, ProductId = 2, Name = "Switch Type", Value = "Cherry MX Brown" },
                    new { ProductAttributeId = 5, ProductId = 2, Name = "Backlight", Value = "RGB" },
                    new { ProductAttributeId = 6, ProductId = 3, Name = "Size", Value = "27-inch" },
                    new { ProductAttributeId = 7, ProductId = 3, Name = "Refresh Rate", Value = "144Hz" },
                    new { ProductAttributeId = 8, ProductId = 4, Name = "Connectivity", Value = "Bluetooth 5.2" },
                    new { ProductAttributeId = 9, ProductId = 4, Name = "Color", Value = "White" }
                );
            });
        }
    }
}
