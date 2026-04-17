using Microsoft.AspNetCore.Mvc;
using Sample.ProductAPI.DataAccess;
using Sample.ProductAPI.Models;

namespace Sample.ProductAPI.Controllers
{
    /// <summary>
    /// API controller for products.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductsController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="logger">The logger.</param>
        public ProductsController(IProductRepository productRepository, ILogger<ProductsController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        /// <summary>
        /// Gets a single product by its ID.
        /// API Path: GET /api/Products/{productId}
        /// </summary>
        /// <param name="productId">The product ID.</param>
        /// <returns>The product.</returns>
        [HttpGet("{productId}")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetProduct(int productId)
        {
            _logger.LogInformation("Getting product with ID: {ProductId}", productId);
            var product = await _productRepository.GetProductAsync(productId);

            if (product == null)
            {
                _logger.LogWarning("Product with ID: {ProductId} not found.", productId);
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        /// Gets a list of all products, ordered by rating.
        /// API Path: GET /api/Products
        /// </summary>
        /// <returns>A list of products.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
        public async Task<IActionResult> GetProducts()
        {
            _logger.LogInformation("Getting all products.");
            var products = await _productRepository.GetProductsAsync();
            return Ok(products);
        }

        /// <summary>
        /// Gets attributes for a specific product.
        /// API Path: GET /api/Products/{productId}/attributes
        /// </summary>
        /// <param name="productId">The product ID.</param>
        /// <returns>A list of product attributes.</returns>
        [HttpGet("{productId}/attributes")]
        [ProducesResponseType(typeof(IEnumerable<ProductAttribute>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetProductAttributes(int productId)
        {
            _logger.LogInformation("Getting attributes for product with ID: {ProductId}", productId);
            var attributes = await _productRepository.GetProductAttributesAsync(productId);

            if (!attributes.Any())
            {                
                // For this exercise, I will return 404 if no attributes are found. Need decision.
                _logger.LogWarning("No attributes found for product with ID: {ProductId}", productId);
                return NotFound();
            }

            return Ok(attributes);
        }
    }
}