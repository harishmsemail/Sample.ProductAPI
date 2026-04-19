using Microsoft.AspNetCore.Mvc;
using Sample.ProductAPI.DataAccess;
using Sample.ProductAPI.Dtos;

namespace Sample.ProductAPI.Controllers
{
    /// <summary>
    /// API controller for managing products.
    /// </summary>
    [ApiController]
    [Route(ApiRoutes.Products.Base)]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductsController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="logger">The logger for this controller.</param>
        public ProductsController(IProductRepository productRepository, ILogger<ProductsController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A list of products.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProducts()
        {
            _logger.LogInformation("Attempting to retrieve all products.");
            try
            {
                var products = await _productRepository.GetProductsAsync();
                _logger.LogInformation("Successfully retrieved {ProductCount} products.", products.Count());
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while retrieving all products.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }
        }

        /// <summary>
        /// Retrieves a specific product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The requested product.</returns>
        [HttpGet(ApiRoutes.Products.GetById)]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProduct(int id)
        {
            _logger.LogInformation("Attempting to retrieve product with ID: {ProductId}", id);
            try
            {
                //First, check if the product exists
                var product = await _productRepository.GetProductAsync(id);
                if (product == null)
                {
                    _logger.LogWarning("Product with ID: {ProductId} was not found.", id);
                    return NotFound();
                }

                _logger.LogInformation("Successfully retrieved product with ID: {ProductId}", id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while retrieving product with ID: {ProductId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }
        }

        /// <summary>
        /// Retrieves all attributes for a specific product.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns>A list of product attributes.</returns>
        [HttpGet(ApiRoutes.Products.GetAttributes)]
        [ProducesResponseType(typeof(IEnumerable<ProductAttributeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProductAttributes(int id)
        {
            _logger.LogInformation("Attempting to retrieve attributes for product with ID: {ProductId}", id);
            try
            {
                //First, check if the product exists
                var product = await _productRepository.GetProductAsync(id);
                if (product == null)
                {
                    _logger.LogWarning("Product with ID: {ProductId} was not found when retrieving attributes.", id);
                    return NotFound();
                }
                
                var attributes = await _productRepository.GetProductAttributesAsync(id);
                _logger.LogInformation("Successfully retrieved {AttributeCount} attributes for product with ID: {ProductId}", attributes.Count(), id);
                return Ok(attributes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while retrieving attributes for product with ID: {ProductId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }
        }
    }
}
