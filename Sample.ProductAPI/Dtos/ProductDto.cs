using Sample.ProductAPI.Models;

namespace Sample.ProductAPI.Dtos
{
    /// <summary>
    /// Data transfer object for a product.
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string? ProductName { get; set; }

        /// <summary>
        /// Gets or sets the price of the product per item.
        /// </summary>
        public decimal PricePerItem { get; set; }

        /// <summary>
        /// Gets or sets the average customer rating for the product.
        /// </summary>
        public decimal AverageCustomerRating { get; set; }

        /// <summary>
        /// Gets or sets the list of attributes for the product.
        /// </summary>
        public List<ProductAttributeDto> Attributes { get; set; } = new List<ProductAttributeDto>();
    }
}
