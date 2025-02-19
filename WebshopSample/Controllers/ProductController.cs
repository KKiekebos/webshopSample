using Microsoft.AspNetCore.Mvc;
using WebshopSample.Models;
using WebshopSample.Repositories;

namespace WebshopSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository) {
            this.productRepository = productRepository;
        }

        [HttpGet("GetProducts")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = productRepository.GetProducts();
            
            if (products == default) 
            {
                return NotFound();
            }

            return products;
        }

        [HttpGet("GetProductById/{id}")]
        public ActionResult<Product> GetProductById(string id)
        {
            var couldParse = Guid.TryParse(id, out var productId);

            if (!couldParse)
            {
                return BadRequest();
            }

            var product = productRepository.GetProductById(productId);

            if (product == default)
            {
                return NotFound();
            } 

            return product;
        }
    }
}
