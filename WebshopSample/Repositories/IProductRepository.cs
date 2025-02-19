using WebshopSample.Models;

namespace WebshopSample.Repositories
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();

        public Product? GetProductById(Guid id);

    }
}
