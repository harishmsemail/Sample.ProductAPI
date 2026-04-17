using Sample.ProductAPI.Models;

namespace Sample.ProductAPI.DataAccess
{
    /// <summary>
    /// A utility class to seed the database with initial data.
    /// </summary>
    public static class DataSeeder
    {
        /// <summary>
        /// Seeds the database with sample product data if it is empty.
        /// </summary>
        /// <param name="app">The application host.</param>
        public static void SeedData(IHost app)
        {
            var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
            if (scopedFactory != null)
            {
                using (var scope = scopedFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<ProductDbContext>();
                    if (context != null)
                    {
                        // Ensure the database is created.
                        context.Database.EnsureCreated();

                        // Check if data already exists to avoid re-seeding
                        if (!context.Products.Any())
                        {
                            var products = new Product[]
                            {
                                new Product { ProductId = 1, ProductName = "Laptop", PricePerItem = 1200.50m, AverageCustomerRating = 4.5 },
                                new Product { ProductId = 2, ProductName = "Mouse", PricePerItem = 25.00m, AverageCustomerRating = 4.8 },
                                new Product { ProductId = 3, ProductName = "Keyboard", PricePerItem = 75.75m, AverageCustomerRating = 4.2 }
                            };
                            context.Products.AddRange(products);

                            var attributes = new ProductAttribute[]
                            {
                                new ProductAttribute { ProductAttributeId = 1, ProductId = 1, Name = "Color", Value = "Silver" },
                                new ProductAttribute { ProductAttributeId = 2, ProductId = 1, Name = "RAM", Value = "16GB" },
                                new ProductAttribute { ProductAttributeId = 3, ProductId = 2, Name = "Color", Value = "Black" },
                                new ProductAttribute { ProductAttributeId = 4, ProductId = 2, Name = "Type", Value = "Wireless" },
                                new ProductAttribute { ProductAttributeId = 5, ProductId = 3, Name = "Layout", Value = "QWERTY" }
                            };
                            context.ProductAttributes.AddRange(attributes);

                            context.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}