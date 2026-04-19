using System.ComponentModel.DataAnnotations;

namespace Sample.ProductAPI.Models
{
    /// <summary>
    /// Represents a product in the catalog.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        [Required]
        [StringLength(100)]
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
        /// Gets or sets the collection of attributes for this product.
        /// </summary>
        public ICollection<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();
    }
}
