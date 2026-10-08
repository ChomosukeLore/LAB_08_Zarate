using Microsoft.AspNetCore.Mvc;
using LAB_08_Zarate.Repositories;

namespace LAB_08_Zarate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("filter-by-price")]
        public IActionResult GetProductsByPrice([FromQuery] decimal minPrice = 20)
        {
            var products = _productRepository.GetProductsWithPriceGreaterThan(minPrice);
            return Ok(products);
        }

        [HttpGet("most-expensive")]
        public IActionResult GetMostExpensiveProduct()
        {
            var product = _productRepository.GetMostExpensiveProduct();
            if (product == null) return NotFound("No se encontraron productos registrados.");
            return Ok(product);
        }

        [HttpGet("average-price")]
        public IActionResult GetAveragePrice()
        {
            var averagePrice = _productRepository.GetAveragePrice();
            return Ok(new { AveragePrice = averagePrice });
        }

        [HttpGet("without-description")]
        public IActionResult GetProductsWithoutDescription()
        {
            var products = _productRepository.GetProductsWithoutDescription();
            return Ok(products);
        }
    }
}