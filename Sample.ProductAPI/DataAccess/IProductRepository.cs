using Sample.ProductAPI.Models;

namespace Sample.ProductAPI.DataAccess
{
    /// <summary>
    /// Defines the contract for a repository managing product data.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Retrieves a single product by its id.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>The <see cref="Product"/> if found; otherwise, <c>null</c>.</returns>
        Task<Product?> GetProductAsync(int productId);

        /// <summary>
        /// Retrieves a list of all products, sorted descending by rating.
        /// </summary>
        /// <returns>An enumerable collection of products.</returns>
        Task<IEnumerable<Product>> GetProductsAsync();

        /// <summary>
        /// Retrieves all attributes for a specific product id.
        /// </summary>
        /// <param name="productId">The ID of the product whose attributes are to be retrieved.</param>
        /// <returns>An enumerable collection of product attributes.</returns>
        Task<IEnumerable<ProductAttribute>> GetProductAttributesAsync(int productId);
    }
}