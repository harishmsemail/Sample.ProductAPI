namespace Sample.ProductAPI.Models
{
    // Represents an attribute for a product
    public class ProductAttribute
    {
        public int ProductAttributeId { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }

        public int ProductId { get; set; }
    }
}