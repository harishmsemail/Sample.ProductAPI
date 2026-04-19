using Sample.ProductAPI.Dtos;
using Sample.ProductAPI.Models;

namespace Sample.ProductAPI.Mappers
{
    /// <summary>
    /// Provides mapping methods for converting between product models and DTOs.
    /// </summary>
    public static class ProductMapper
    {
        /// <summary>
        /// Maps a <see cref="Product"/> to a <see cref="ProductDto"/>.
        /// </summary>
        /// <param name="product">The product to map.</param>
        /// <returns>The mapped product DTO.</returns>
        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                PricePerItem = product.PricePerItem,
                AverageCustomerRating = product.AverageCustomerRating,
                Attributes = product.Attributes?.Select(a => a.ToDto()).ToList() ?? new List<ProductAttributeDto>()
            };
        }

        /// <summary>
        /// Maps a <see cref="ProductAttribute"/> to a <see cref="ProductAttributeDto"/>.
        /// </summary>
        /// <param name="attribute">The product attribute to map.</param>
        /// <returns>The mapped product attribute DTO.</returns>
        public static ProductAttributeDto ToDto(this ProductAttribute attribute)
        {
            return new ProductAttributeDto
            {
                AttributeName = attribute.Name,
                AttributeValue = attribute.Value
            };
        }
    }
}
