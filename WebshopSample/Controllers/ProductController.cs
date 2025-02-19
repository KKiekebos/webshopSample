using Microsoft.AspNetCore.Mvc;

namespace WebshopSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {


        public ProductController()
        {
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                Name = $"Product {index}",
                Description = $"The product with index {index}",
                Options = [],
                Image = "image"
            })
            .ToArray();
        }
    }
}
