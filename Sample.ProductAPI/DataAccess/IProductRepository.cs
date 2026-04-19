using Sample.ProductAPI.Dtos;
using Sample.ProductAPI.Models;

namespace Sample.ProductAPI.DataAccess
{
    /// <summary>
    /// Defines the contract for a product repository.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Retrieves a single product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>The product, or null if not found.</returns>
        Task<ProductDto?> GetProductAsync(int productId);

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A collection of all products.</returns>
        Task<IEnumerable<ProductDto>> GetProductsAsync();

        /// <summary>
        /// Retrieves all attributes for a given product.
        /// </summary>
        /// <param name="productId">The ID of the product.</param>
        /// <returns>A collection of product attributes.</returns>
        Task<IEnumerable<ProductAttributeDto>> GetProductAttributesAsync(int productId);
    }
}
