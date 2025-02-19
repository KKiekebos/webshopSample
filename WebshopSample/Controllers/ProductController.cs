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

        [HttpGet(Name = "GetProducts")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "GetProductById/{id}")]
        public ActionResult<Product> GetProductById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
