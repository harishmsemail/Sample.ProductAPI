using Microsoft.EntityFrameworkCore;
using Sample.ProductAPI.Models;

namespace Sample.ProductAPI.DataAccess
{
    /// <summary>
    /// Repository for managing products.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Product?> GetProductAsync(int productId)
        {
            // Retrieve a single product by its ID.
            return await _context.Products.FindAsync(productId);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            // Retrieve all products, ordered by average customer rating in descending order.
            return await _context.Products.OrderByDescending(p => p.AverageCustomerRating).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ProductAttribute>> GetProductAttributesAsync(int productId)
        {
            // Retrieve all attributes for a given product ID.
            return await _context.ProductAttributes.Where(pa => pa.ProductId == productId).ToListAsync();
        }
    }
}