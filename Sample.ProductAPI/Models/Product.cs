namespace Sample.ProductAPI.Models
{
    // Represents a product in the catalog.
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal PricePerItem { get; set; }
        public double AverageCustomerRating { get; set; }
        public ICollection<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();
    }
}