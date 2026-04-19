namespace Sample.ProductAPI.Models
{
    /// <summary>
    /// Represents a single attribute (like color, size, or material) for a product.
    /// </summary>
    public class ProductAttribute
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product attribute.
        /// </summary>
        public int ProductAttributeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the attribute (e.g., "Color").
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the attribute (e.g., "Red").
        /// </summary>
        public string? Value { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the associated product.
        /// </summary>
        public int ProductId { get; set; }
    }
}
