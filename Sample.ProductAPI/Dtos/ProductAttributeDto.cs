namespace Sample.ProductAPI.Dtos
{
    /// <summary>
    /// Represents a product attribute.
    /// </summary>
    public class ProductAttributeDto
    {
        /// <summary>
        /// The attribute's name.
        /// </summary>
        public string? AttributeName { get; set; }

        /// <summary>
        /// The attribute's value.
        /// </summary>
        public string? AttributeValue { get; set; }
    }
}
