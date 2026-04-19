using Microsoft.EntityFrameworkCore;
using Sample.ProductAPI.Dtos;
using Sample.ProductAPI.Mappers;
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
        public async Task<ProductDto?> GetProductAsync(int productId)
        {
            // Retrieve a single product by its ID, including its attributes.
            var product = await _context.Products
                .Include(p => p.Attributes)
                .FirstOrDefaultAsync(p => p.ProductId == productId);

            return product?.ToDto();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            // Retrieve all products, ordered by average customer rating in descending order.
            var products = await _context.Products
                .Include(p => p.Attributes)
                .OrderByDescending(p => p.AverageCustomerRating)
                .ToListAsync();

            return products.Select(p => p.ToDto());
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ProductAttributeDto>> GetProductAttributesAsync(int productId)
        {
            // Retrieve all attributes for a given product ID.
            return await _context.ProductAttributes
                .Where(pa => pa.ProductId == productId)
                .Select(pa => pa.ToDto())
                .ToListAsync();
        }
    }
}
